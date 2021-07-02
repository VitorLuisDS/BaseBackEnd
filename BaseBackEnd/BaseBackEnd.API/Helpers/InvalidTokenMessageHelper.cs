using BaseBackEnd.Domain.Constants.Messages;
using BaseBackEnd.Domain.Enums;

namespace BaseBackEnd.API.Helpers
{
    public static class InvalidTokenMessageHelper
    {
        public static string GetMessageFromTokenTypeAndInvalidTokenType(TokenType tokenType, InvalidTokenType invalidTokenType)
        {
            string message = invalidTokenType switch
            {
                InvalidTokenType.Expired => SecurityMessages.EXPIRED_TOKEN_MSG,
                InvalidTokenType.NotProvided => tokenType switch
                {
                    TokenType.AccessToken => SecurityMessages.NO_ACCESS_TOKEN_MSG,
                    TokenType.RefreshToken => SecurityMessages.NO_REFRESH_TOKEN_MSG,
                    _ => SecurityMessages.INVALID_TOKEN_MSG
                },
                InvalidTokenType.Blacklisted => SecurityMessages.BLACKLISTED_TOKEN_MSG,
                _ => SecurityMessages.INVALID_TOKEN_MSG
            };

            return message;
        }
    }
}
