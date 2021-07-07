using BaseBackEnd.Security.API.Models;
using BaseBackEnd.Security.API.Models.Base;
using BaseBackEnd.Security.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.API.Helpers
{
    public static class UnsuccessResponseHelper
    {

        public static async Task WriteAndCompleteUnauthorizedJsonAsync(this HttpResponse httpResponse, TokenType tokenType, InvalidTokenType invalidTokenType)
        {
            var invalidTokenResponse = new InvalidTokenResponse(tokenType, invalidTokenType);
            var message = InvalidTokenMessageHelper.GetMessageFromTokenTypeAndInvalidTokenType(tokenType, invalidTokenType);

            httpResponse.StatusCode = (int)HttpStatusCode.Unauthorized;
            await httpResponse.WriteAsJsonAsync(new ResponseBase<InvalidTokenResponse>(invalidTokenResponse, (HttpStatusCode)httpResponse.StatusCode, message));
            await httpResponse.CompleteAsync();
        }
    }
}
