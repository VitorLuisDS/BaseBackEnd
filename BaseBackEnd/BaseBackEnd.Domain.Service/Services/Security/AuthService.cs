using BaseBackEnd.Domain.Config;
using BaseBackEnd.Domain.Constants;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Domain.Service.Services.Base;
using BaseBackEnd.Domain.ViewModels.SecutityVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Service.Services.Security
{
    public class AuthService : ServiceBase<User>, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ISessionBlackListRepository _sessionBlackListRepository;
        private readonly IUnityOfWork _unityOfWork;

        private InvalidTokenType _invalidTokenType { get; set; }
        public InvalidTokenType InvalidTokenType => _invalidTokenType;

        public const string HEADER_ORIGIN = "origin";

        private readonly TokenConfig _tokenConfig;
        private readonly string _tokenIssuer;

        public string _tokenAudience { get; set; }

        public readonly string ClaimTypeName = ClaimTypes.Name;
        public readonly string ClaimTypeNameUser = "name";
        public readonly string ClaimTypeProfileName = "profileName";
        public readonly string ClaimTypeProfileId = "profileId";
        public readonly string ClaimTypeNameIdentifier = ClaimTypes.NameIdentifier;
        public readonly string ClaimTypeRole = ClaimTypes.Role;
        public readonly string ClaimTypeSid = "sid";
        public readonly string ClaimTypeStayConnected = "stayConnected";

        public AuthService(
            IUserRepository userRepository,
            ISessionRepository sessionRepository,
            ISessionBlackListRepository sessionBlackListRepository,
            IOptions<TokenConfig> options,
            IHttpContextAccessor httpContextAccessor,
            IUnityOfWork unityOfWork
            ) : base(userRepository)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _sessionBlackListRepository = sessionBlackListRepository;
            _unityOfWork = unityOfWork;
            _tokenConfig = options.Value;
            _tokenAudience = httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.Equals(HEADER_ORIGIN)).Value;
            _tokenIssuer = httpContextAccessor.HttpContext.Request.Host.ToUriComponent();
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
                    StayConnected = stayConnected,
                    Roles = user.Profile?.ProfileModulePageFunctionalities?.Select(x =>
                        $"{x?.ModulePageFunctionality?.ModulePage?.Module?.Code}-{x?.ModulePageFunctionality?.ModulePage?.Page?.Code}-{x?.ModulePageFunctionality?.Functionality?.Code}").ToArray()
                };
            }

            return usuarioVm;
        }

        private string GenerateToken(TimeSpan duration, ClaimsIdentity identity)
        {
            var handler = new JwtSecurityTokenHandler();

            DateTime creationDate = DateTime.UtcNow;

            DateTime expirationDate = creationDate + duration;

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenIssuer,
                Audience = _tokenAudience,
                SigningCredentials = SigningCredentials(),
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }

        private string GenerateAccessToken(AuthenticatedUserOutputVm authenticatedUserOutputVm)
        {
            if (authenticatedUserOutputVm != null)
            {
                var claims = GenerateClaimsForAccessToken(authenticatedUserOutputVm);
                foreach (var item in authenticatedUserOutputVm.Roles)
                {
                    claims.Add(new Claim(ClaimTypeRole, item));
                }
                ClaimsIdentity identity = new ClaimsIdentity(claims.ToArray());
                return GenerateToken(TimeSpan.FromSeconds(_tokenConfig.AccessTokenDurationInSeconds), identity);
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
                return GenerateToken(authenticatedUserOutputVm.StayConnected ? TimeSpan.FromDays(365) : TimeSpan.FromMinutes(_tokenConfig.RefreshTokenDurationInMinutes), identity);
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

            var content = ReadJwtToken(token);
            if (content == default) return result;

            string sid = content.Claims?.Where(i => i.Type.Equals(ClaimTypeSid))?.FirstOrDefault()?.Value;

            result = new AuthenticatedUserOutputVm
            {
                Login = content.Claims.Where(i => i.Type.Equals(ClaimTypeNameIdentifier)).FirstOrDefault()?.Value,
                Name = content.Claims.Where(i => i.Type.Equals(ClaimTypeName)).FirstOrDefault()?.Value,
                Roles = content.Claims.Where(i => i.Type.Equals(ClaimTypeRole)).Select(i => i.Value).ToArray(),
                StayConnected = bool.Parse(content.Claims.FirstOrDefault(i => i.Type.Equals(ClaimTypeStayConnected))?.Value ?? false.ToString())
            };

            if (sid != null)
            {
                result.Sid = Guid.Parse(sid);
            }
            return result;
        }

        public async Task<bool> ValidateToken(string token, string tokenAudience = null)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            if (token.StartsWith(SecurityConstants.AUTHENTICATION_HEADER_TYPE))
                token = token.Substring(7);

            var sid = GetSidFromToken(token);
            if (sid == default)
            {
                _invalidTokenType = InvalidTokenType.Other;
                return false;
            }

            if (tokenAudience != null)
            {
                _tokenAudience = tokenAudience;
            }

            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidateAudience = false, // to do
                ValidateIssuer = true, // to do
                IssuerSigningKey = SymmetricSecurityKey(),
                ValidAudience = _tokenAudience,
                ValidIssuer = _tokenIssuer,
                ClockSkew = TimeSpan.Zero
            };

            var isTokenOnblackList = await _sessionBlackListRepository.IsSessionOnBlackListAsync(sid);
            if (isTokenOnblackList)
            {
                _invalidTokenType = InvalidTokenType.Blacklisted;
                return false;
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                _invalidTokenType = InvalidTokenType.Expired;
                return false;
            }
            catch
            {
                _invalidTokenType = InvalidTokenType.Other;
                return false;
            }
        }

        private JwtSecurityToken ReadJwtToken(string token)
        {
            var jwt = new JwtSecurityTokenHandler();
            try
            {
                return jwt.ReadJwtToken(token);
            }
            catch
            {
                return default;
            }
        }

        private Guid GetSidFromToken(string token)
        {
            var content = ReadJwtToken(token);
            if (content == default) return default;

            string sidString = content.Claims?.Where(i => i.Type.Equals(ClaimTypeSid))?.FirstOrDefault()?.Value;
            if (string.IsNullOrWhiteSpace(sidString))
                return default;

            Guid sid;
            if (!Guid.TryParse(sidString, out sid))
                return default;

            return sid;
        }

        private SymmetricSecurityKey SymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenConfig.Secret));
        }

        /// <summary>Retorna as credenciais de assinatura para o token</summary>
        private SigningCredentials SigningCredentials()
        {
            return new SigningCredentials(SymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
