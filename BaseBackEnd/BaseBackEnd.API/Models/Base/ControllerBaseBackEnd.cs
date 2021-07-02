using BaseBackEnd.API.Helpers;
using BaseBackEnd.API.Models.Attributes;
using BaseBackEnd.Domain.Constants.Security;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms;
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

        public ControllerBaseBackEnd(IAuthenticationService authenticationService = null)
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
        protected void SetAccessTokenOnCookies(TokensOutputVm user)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            };

            HttpContext.Response.Cookies.Append(AuthConstants.REFRESH_TOKEN_NAME, user.RefreshToken, cookieOptions);
        }

        protected async Task<User> GetUserFromTokenAsync()
        {
            
        }
    }
}
