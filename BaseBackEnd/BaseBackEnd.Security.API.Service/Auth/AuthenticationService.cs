using BaseBackEnd.Security.API.ViewModels.SecutityVms.TokenVms;
using BaseBackEnd.Security.API.ViewModels.UserVms;
using BaseBackEnd.Security.Domain.Configs;
using BaseBackEnd.Security.Domain.Enums;
using BaseBackEnd.Security.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Security.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.API.Services.Auth
{
    public class AuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly TokenService _tokenService;

        public InvalidTokenType InvalidTokenType => _tokenService.InvalidTokenType;

        public const string HEADER_ORIGIN = "origin";

        private readonly TokenConfig _tokenConfig;

        public string _tokenAudience { get; set; }

        public readonly string ClaimTypeName = ClaimTypes.Name;
        public readonly string ClaimTypeNameUser = "name";
        public readonly string ClaimTypeProfileName = "profileName";
        public readonly string ClaimTypeNameIdentifier = ClaimTypes.NameIdentifier;
        public readonly string ClaimTypeSid = "sid";
        public readonly string ClaimTypeStayConnected = "stayConnected";

        public AuthenticationService(
            IUserRepository userRepository,
            ISessionRepository sessionRepository,
            IOptions<TokenConfig> options,
            IHttpContextAccessor httpContextAccessor,
            IUnityOfWork unityOfWork,
            TokenService tokenService
            )
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
            var user = await _userRepository.GetUserByLoginAndPasswordAsync(userAuthInput.Login, userAuthInput.Password);
            if (user != default)
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
            TokensOutputVm accessTokenOutput = default;
            if (dadosDoToken != default)
            {
                Session session = await _sessionRepository.GetSessionAndUserWithProfilesAsync(dadosDoToken.Sid);
                if (session != default)
                {
                    AuthenticatedUserOutputVm authenticatedUser = PopulateUserData(session.User, session.Id, dadosDoToken.StayConnected);
                    accessTokenOutput = new TokensOutputVm() { AccessToken = GenerateAccessToken(authenticatedUser), RefreshToken = GenerateRefreshToken(authenticatedUser) };
                }
            }

            return accessTokenOutput;
        }

        private AuthenticatedUserOutputVm PopulateUserData(User user, Guid sid, bool stayConnected)
        {
            AuthenticatedUserOutputVm usuarioVm = default;
            if (user != default)
            {
                var profilesNames = user
                    .UserProfiles
                    ?.Select(x => x.Profile.Name)
                    ?.ToArray() ?? new string[0];

                usuarioVm = new AuthenticatedUserOutputVm()
                {
                    Login = user.Login,
                    Name = user.Name,
                    ProfilesNames = profilesNames,
                    Sid = sid,
                    StayConnected = stayConnected
                };
            }

            return usuarioVm;
        }

        private string GenerateAccessToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            if (authenticatedUserOutputVm != default)
            {
                var claims = GenerateClaimsForAccessToken(authenticatedUserOutputVm);
                ClaimsIdentity identity = new ClaimsIdentity(claims.ToArray());
                return _tokenService.GenerateToken(TimeSpan.FromSeconds(_tokenConfig.AccessTokenDurationInSeconds)/*TimeSpan.FromDays(365 / 2)*/, identity);
            }
            else
            {
                return default;
            }
        }

        private string GenerateRefreshToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            if (authenticatedUserOutputVm != default)
            {
                var claims = GenerateClaimsForRefreshToken(authenticatedUserOutputVm);
                ClaimsIdentity identity = new ClaimsIdentity(claims.ToArray());
                return _tokenService.GenerateToken(authenticatedUserOutputVm.StayConnected ? TimeSpan.FromDays(365) : TimeSpan.FromMinutes(_tokenConfig.RefreshTokenDurationInMinutes), identity);
            }
            else
            {
                return default;
            }
        }

        private List<Claim> GenerateClaimsForAccessToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypeName, authenticatedUserOutputVm.Login));

            claims.Add(new Claim(ClaimTypeNameIdentifier, authenticatedUserOutputVm.Login));

            claims.Add(new Claim(ClaimTypeNameUser, authenticatedUserOutputVm.Name));

            claims.Add(new Claim(ClaimTypeSid, authenticatedUserOutputVm.Sid.ToString()));

            foreach (var profileName in authenticatedUserOutputVm.ProfilesNames)
            {
                claims.Add(new Claim(ClaimTypeProfileName, profileName));
            }

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
            AuthenticatedUserOutputVm result = default;

            var content = _tokenService.ReadJwtToken(token);
            if (content == default) return result;

            string sid = content.Claims?.Where(i => i.Type.Equals(ClaimTypeSid))?.FirstOrDefault()?.Value;

            result = new AuthenticatedUserOutputVm
            {
                Login = content.Claims.Where(i => i.Type.Equals(ClaimTypeNameIdentifier)).FirstOrDefault()?.Value,
                Name = content.Claims.Where(i => i.Type.Equals(ClaimTypeName)).FirstOrDefault()?.Value,
                StayConnected = bool.Parse(content.Claims.FirstOrDefault(i => i.Type.Equals(ClaimTypeStayConnected))?.Value ?? false.ToString())
            };

            if (sid != default)
            {
                result.Sid = Guid.Parse(sid);
            }
            return result;
        }

        public async Task<User> GetUserFromTokenAsync(string token)
        {
            var dadosDoToken = TokenToAuthenticatedUserOutputVm(token);
            User user = default;
            if (dadosDoToken != default)
                user = await _sessionRepository.GetUserFromSessionIdAsync(dadosDoToken.Sid);

            return user;
        }
    }
}
