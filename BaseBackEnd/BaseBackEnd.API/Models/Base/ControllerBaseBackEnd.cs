using BaseBackEnd.API.Models.Attributes;
using BaseBackEnd.Domain.Constants;
using BaseBackEnd.Domain.Constants.Messages;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.ViewModels.SecutityVms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseBackEnd.API.Models.Base
{
    [ProducesResponseTypeBase(typeof(ResponseBase), HttpStatusCode.InternalServerError)]
    public class ControllerBaseBackEnd : ControllerBase
    {
        [NonAction]
        protected IActionResult ResponseUnsuccessfulResultByInvalidTokenType(InvalidTokenType invalidTokenType)
        {
            return invalidTokenType switch
            {
                InvalidTokenType.Expired => Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.EXPIRED_TOKEN_MSG)),
                InvalidTokenType.Blacklisted => Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.BLACKLISTED_TOKEN_MSG)),
                _ => Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.INVALID_TOKEN_MSG))
            };
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

            HttpContext.Response.Cookies.Append(SecurityConstants.REFRESH_TOKEN_NAME, user.RefreshToken, cookieOptions);
        }
    }
}
