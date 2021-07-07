using BaseBackEnd.Security.Domain.Enums;

namespace BaseBackEnd.Security.API.Models
{
    public class InvalidTokenResponse
    {
        public InvalidTokenResponse(TokenType tokenType, InvalidTokenType invalidTokenType)
        {
            TokenType = tokenType;
            InvalidTokenType = invalidTokenType;
        }

        public TokenType TokenType { get; set; }
        public InvalidTokenType InvalidTokenType { get; set; }
    }
}
