using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseBackEnd.Service.Security
{
    public class TokenService : ITokenService
    {
        private readonly ISessionBlackListRepository _sessionBlackListRepository;

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

        public TokenService(
            ISessionBlackListRepository sessionBlackListRepository,
            IOptions<TokenConfig> options,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _sessionBlackListRepository = sessionBlackListRepository;
            _tokenConfig = options.Value;
            _tokenAudience = httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.Equals(HEADER_ORIGIN)).Value;
            _tokenIssuer = httpContextAccessor.HttpContext.Request.Host.ToUriComponent();
        }

        public string GenerateToken(TimeSpan duration, ClaimsIdentity identity)
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

        public async Task<bool> ValidateToken(string token, string tokenAudience = default)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            var sid = GetSidFromToken(token);
            if (sid == default)
            {
                _invalidTokenType = InvalidTokenType.Other;
                return false;
            }

            if (tokenAudience != default)
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

        public JwtSecurityToken ReadJwtToken(string token)
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

        public Guid GetSidFromToken(string token)
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
