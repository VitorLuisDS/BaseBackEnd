using BaseBackEnd.Security.Domain.Enums;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Service.Security
{
    public interface ITokenService
    {
        InvalidTokenType InvalidTokenType { get; }
        Task<bool> ValidateToken(string token, string tokenAudience = default);
        Guid GetSidFromToken(string token);
        string GenerateToken(TimeSpan duration, ClaimsIdentity identity);
        JwtSecurityToken ReadJwtToken(string token);
    }
}
