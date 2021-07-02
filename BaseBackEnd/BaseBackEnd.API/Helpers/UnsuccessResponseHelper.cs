using BaseBackEnd.API.Models;
using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Helpers
{
    public static class UnsuccessResponseHelper
    {

        public static async Task WriteAndCompleteJsonAsync(this HttpResponse httpResponse, TokenType tokenType, InvalidTokenType invalidTokenType)
        {
            var invalidTokenResponse = new InvalidTokenResponse(tokenType, invalidTokenType);
            var message = InvalidTokenMessageHelper.GetMessageFromTokenTypeAndInvalidTokenType(tokenType, invalidTokenType);

            httpResponse.StatusCode = (int)HttpStatusCode.Unauthorized;
            await httpResponse.WriteAsJsonAsync(new ResponseBase<InvalidTokenResponse>(invalidTokenResponse, (HttpStatusCode)httpResponse.StatusCode, message));
            await httpResponse.CompleteAsync();
        }
    }
}
