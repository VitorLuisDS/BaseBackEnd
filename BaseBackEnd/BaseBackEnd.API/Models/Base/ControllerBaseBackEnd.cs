using BaseBackEnd.API.Constants.Security;
using BaseBackEnd.API.Helpers;
using BaseBackEnd.API.Models.Attributes;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Models.Base
{
    [ProducesResponseTypeBase(typeof(ResponseBase), HttpStatusCode.InternalServerError)]
    public abstract class ControllerBaseBackEnd : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        protected Task<int> UserId => GetUserIdFromTokenAsync();
        protected new Task<User> User => GetUserFromTokenAsync();
        public ControllerBaseBackEnd(IAuthenticationService authenticationService = default)
        {
            _authenticationService = authenticationService;
        }

        [NonAction]
        protected IActionResult UnauthorizedResponseByInvalidTokenType(TokenType tokenType, InvalidTokenType invalidTokenType)
        {
            var invalidTokenResponse = new InvalidTokenResponse(tokenType, invalidTokenType);
            var message = InvalidTokenMessageHelper.GetMessageFromTokenTypeAndInvalidTokenType(tokenType, invalidTokenType);
            return Unauthorized(new ResponseBase<InvalidTokenResponse>(invalidTokenResponse, HttpStatusCode.Unauthorized, message));
        }

        [NonAction]
        private async Task<User> GetUserFromTokenAsync()
        {
            var refreshToken = HttpContext.Request.GetCookieValue(AuthConstants.REFRESH_TOKEN_NAME);
            if (refreshToken != default)
                return await _authenticationService.GetUserFromTokenAsync(refreshToken);
            return default;
        }

        [NonAction]
        private async Task<int> GetUserIdFromTokenAsync()
        {
            var user = await GetUserFromTokenAsync();
            if (user == default)
                return default;
            return user.Id;
        }
    }
}
