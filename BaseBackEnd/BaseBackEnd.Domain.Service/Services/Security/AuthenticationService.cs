using BaseBackEnd.Domain.Config;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Domain.Service.Services.Base;
using BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Service.Services.Security
{
    public class AuthenticationService : ServiceBase<User>, IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly ITokenService _tokenService;

        public InvalidTokenType InvalidTokenType => _tokenService.InvalidTokenType;

        public const string HEADER_ORIGIN = "origin";

        private readonly TokenConfig _tokenConfig;

        public string _tokenAudience { get; set; }

        public readonly string ClaimTypeName = ClaimTypes.Name;
        public readonly string ClaimTypeNameUser = "name";
        public readonly string ClaimTypeProfileName = "profileName";
        public readonly string ClaimTypeProfileId = "profileId";
        public readonly string ClaimTypeNameIdentifier = ClaimTypes.NameIdentifier;
        public readonly string ClaimTypeSid = "sid";
        public readonly string ClaimTypeStayConnected = "stayConnected";

        public AuthenticationService(
            IUserRepository userRepository,
            ISessionRepository sessionRepository,
            IOptions<TokenConfig> options,
            IHttpContextAccessor httpContextAccessor,
            IUnityOfWork unityOfWork,
            ITokenService tokenService
            ) : base(userRepository)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _tokenService = tokenService;
            _unityOfWork = unityOfWork;
            _tokenConfig = options.Value;
            _tokenAudience = httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.Equals(HEADER_ORIGIN)).Value;
        }

        public async Task<TokensOutputVm> AuthenticateAsync(UserAuthInputVm userAuthInput)
        {
            var user = await _userRepository.AuthenticateAsync(userAuthInput);
            if (user != null)
            {
                Session session = await _sessionRepository.AddAsync(user.Id, userAuthInput.StayConnected);
                await _unityOfWork.CommitAsync();
                AuthenticatedUserOutputVm authenticatedUser = PopulateUserData(user, session.Id, userAuthInput.StayConnected);

                return new TokensOutputVm() { AccessToken = GenerateAccessToken(authenticatedUser), RefreshToken = GenerateRefreshToken(authenticatedUser) };
            }
            else
                return default;
        }

        public async Task<TokensOutputVm> AuthenticateByTokenAsync(string token)
        {
            var dadosDoToken = TokenToAuthenticatedUserOutputVm(token);
            TokensOutputVm accessTokenOutput = null;
            if (dadosDoToken != null)
            {
                Session session = await _sessionRepository.GetSessionAndUserAsync(dadosDoToken.Sid);
                if (session != null)
                {
                    AuthenticatedUserOutputVm authenticatedUser = PopulateUserData(session.User, session.Id, dadosDoToken.StayConnected);
                    accessTokenOutput = new TokensOutputVm() { AccessToken = GenerateAccessToken(authenticatedUser), RefreshToken = GenerateRefreshToken(authenticatedUser) };
                }
            }

            return accessTokenOutput;
        }

        private AuthenticatedUserOutputVm PopulateUserData(User user, Guid sid, bool stayConnected)
        {
            AuthenticatedUserOutputVm usuarioVm = null;
            if (user != null)
            {
                usuarioVm = new AuthenticatedUserOutputVm()
                {
                    Login = user.Login,
                    Name = user.Name,
                    ProfileId = user.IdProfile,
                    ProfileName = user.Profile?.Name,
                    Sid = sid,
                    StayConnected = stayConnected
                };
            }

            return usuarioVm;
        }

        private string GenerateAccessToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            if (authenticatedUserOutputVm != null)
            {
                var claims = GenerateClaimsForAccessToken(authenticatedUserOutputVm);
                ClaimsIdentity identity = new ClaimsIdentity(claims.ToArray());
                return _tokenService.GenerateToken(TimeSpan.FromSeconds(_tokenConfig.AccessTokenDurationInSeconds)/*TimeSpan.FromDays(365/2)*/, identity);
            }
            else
            {
                return null;
            }
        }

        private string GenerateRefreshToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            if (authenticatedUserOutputVm != null)
            {
                var claims = GenerateClaimsForRefreshToken(authenticatedUserOutputVm);
                ClaimsIdentity identity = new ClaimsIdentity(claims.ToArray());
                return _tokenService.GenerateToken(authenticatedUserOutputVm.StayConnected ? TimeSpan.FromDays(365) : TimeSpan.FromMinutes(_tokenConfig.RefreshTokenDurationInMinutes), identity);
            }
            else
            {
                return null;
            }
        }

        private List<Claim> GenerateClaimsForAccessToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypeName, authenticatedUserOutputVm.Login));

            claims.Add(new Claim(ClaimTypeNameIdentifier, authenticatedUserOutputVm.Login));

            claims.Add(new Claim(ClaimTypeNameUser, authenticatedUserOutputVm.Name));

            claims.Add(new Claim(ClaimTypeProfileName, authenticatedUserOutputVm.ProfileName));

            claims.Add(new Claim(ClaimTypeProfileId, authenticatedUserOutputVm.ProfileId.ToString()));

            claims.Add(new Claim(ClaimTypeSid, authenticatedUserOutputVm.Sid.ToString()));

            return claims;
        }

        private List<Claim> GenerateClaimsForRefreshToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypeSid, authenticatedUserOutputVm.Sid.ToString()));

            claims.Add(new Claim(ClaimTypeStayConnected, authenticatedUserOutputVm.StayConnected.ToString()));

            return claims;
        }

        public AuthenticatedUserOutputVm TokenToAuthenticatedUserOutputVm(string token)
        {
            AuthenticatedUserOutputVm result = null;

            var content = _tokenService.ReadJwtToken(token);
            if (content == default) return result;

            string sid = content.Claims?.Where(i => i.Type.Equals(ClaimTypeSid))?.FirstOrDefault()?.Value;

            result = new AuthenticatedUserOutputVm
            {
                Login = content.Claims.Where(i => i.Type.Equals(ClaimTypeNameIdentifier)).FirstOrDefault()?.Value,
                Name = content.Claims.Where(i => i.Type.Equals(ClaimTypeName)).FirstOrDefault()?.Value,
                StayConnected = bool.Parse(content.Claims.FirstOrDefault(i => i.Type.Equals(ClaimTypeStayConnected))?.Value ?? false.ToString())
            };

            if (sid != null)
            {
                result.Sid = Guid.Parse(sid);
            }
            return result;
        }
    }
}
