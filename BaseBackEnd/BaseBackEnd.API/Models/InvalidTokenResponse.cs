using BaseBackEnd.Domain.Enums;

namespace BaseBackEnd.API.Models
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
