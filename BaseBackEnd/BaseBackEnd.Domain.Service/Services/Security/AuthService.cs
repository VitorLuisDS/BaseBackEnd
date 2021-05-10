using BaseBackEnd.Domain.Config;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
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
using System.Security;
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

        private Exception _validationExceptionType { get; set; }
        public Exception ValidationExceptionType => _validationExceptionType;

        private readonly TokenConfig _tokenConfig;

        public const string UNAUTHORIZED_MSG = "Not authorized";
        public const string EXPIRED_TOKEN_MSG = "Token expired";
        public const string INVALID_TOKEN_MSG = "Invalid token";
        public const string HEADER_ORIGIN = "origin";

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
            IOptions<TokenConfig> options,
            IHttpContextAccessor httpContextAccessor
            ) : base(userRepository)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _tokenConfig = options.Value;
            _tokenAudience = httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.Equals(HEADER_ORIGIN)).Value;
            _tokenIssuer = httpContextAccessor.HttpContext.Request.Host.ToUriComponent();
        }

        public async Task<AccessTokenOutputVm> AuthenticateAsync(UserAuthInputVm userAuthInput)
        {
            var user = await _userRepository.AuthenticateAsync(userAuthInput);
            if (user != null)
            {
                Session session = await _sessionRepository.AddAsync(user.Id, userAuthInput.StayConnected);
                AuthenticatedUserOutputVm authenticatedUser = PopulateUserData(user, session.Id, userAuthInput.StayConnected);

                return new AccessTokenOutputVm() { Token = GenerateAccessToken(authenticatedUser), RefreshToken = GenerateRefreshToken(authenticatedUser) };
            }
            else
            {
                throw new SecurityException("Usuário ou Senha Inválido(s).");
            }
        }

        public async Task<AccessTokenOutputVm> AuthenticateByTokenAsync(string token)
        {
            var dadosDoToken = TokenToAuthenticatedUserOutputVm(token);
            AccessTokenOutputVm accessTokenOutput = null;
            if (dadosDoToken != null)
            {
                Session session = await _sessionRepository.GetSessionAndUserAsync(dadosDoToken.Sid);
                if (session != null)
                {
                    AuthenticatedUserOutputVm authenticatedUser = PopulateUserData(session.User, session.Id, dadosDoToken.StayConnected);
                    accessTokenOutput = new AccessTokenOutputVm() { Token = GenerateAccessToken(authenticatedUser), RefreshToken = GenerateRefreshToken(authenticatedUser) };
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
                    Roles = user.Profile.ProfileModulePageFunctionalities.Select(x => $"{x.IdModule}-{x.IdPage}-{x.IdFunctionality}").ToArray()
                };
            }

            return usuarioVm;
        }

        private string GenerateToken(TimeSpan duration, ClaimsIdentity identity)
        {
            var handler = new JwtSecurityTokenHandler();

            DateTime creationDate = DateTime.Now;

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
                var claims = GenerateClaims(authenticatedUserOutputVm);
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
                var claims = GenerateClaims(authenticatedUserOutputVm);
                ClaimsIdentity identity = new ClaimsIdentity(claims.ToArray());
                return GenerateToken(authenticatedUserOutputVm.StayConnected ? TimeSpan.FromDays(50000) : TimeSpan.FromMinutes(_tokenConfig.RefreshTokenDurationInMinutes), identity);
            }
            else
            {
                return null;
            }
        }

        private List<Claim> GenerateClaims(AuthenticatedUserOutputVm authenticatedUserOutputVm)
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

        public AuthenticatedUserOutputVm TokenToAuthenticatedUserOutputVm(string token)
        {
            AuthenticatedUserOutputVm result = null;

            var jwt = new JwtSecurityTokenHandler();

            var content = jwt.ReadJwtToken(token);

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

        public bool ValidateToken(string token, string tokenAudience = null)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            if (token.StartsWith("Bearer "))
                token = token.Substring(7);

            if (tokenAudience != null)
            {
                _tokenAudience = tokenAudience;
            }

            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidateAudience = false, // to do
                ValidateIssuer = false, // to do
                IssuerSigningKey = SymmetricSecurityKey(),
                ValidAudience = _tokenAudience,
                ValidIssuer = _tokenIssuer,
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                _validationExceptionType = new SecurityTokenExpiredException(EXPIRED_TOKEN_MSG);
                return false;
            }
            catch
            {
                _validationExceptionType = new UnauthorizedAccessException(INVALID_TOKEN_MSG);
                return false;
            }
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
