using BaseBackEnd.API.Constants.Endpoints;
using BaseBackEnd.API.Models.Attributes;
using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Constants;
using BaseBackEnd.Domain.Constants.Messages;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Controllers
{
    [Route(AuthEndpoints.BASE_ENDPOINT)]
    [ApiController]
    public class AuthController : ControllerBaseBackEnd
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(AuthEndpoints.AUTHENTICATE)]
        [ProducesBase(typeof(ResponseBase<AccessTokenOutputVm>))]
        [ProducesResponseTypeBase(typeof(ResponseBase), HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthInputVm userAuthInputVm)
        {
            var user = await _authService.AuthenticateAsync(userAuthInputVm);
            if (user != default)
            {
                SetAccessTokenOnCookies(user);
                var response = new ResponseBase<AccessTokenOutputVm>(user, message: SecurityMessages.USER_AUTHENTICATED_MSG);
                return Ok(response);
            }
            else
                return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.USER_DOES_NOT_EXIST_MSG));
        }

        [HttpPost(AuthEndpoints.RENEW_ACCESS_TOKEN)]
        [ProducesBase(typeof(ResponseBase<AccessTokenOutputVm>))]
        [ProducesResponseTypeBase(HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> RenewAccessToken()
        {
            string refreshToken;
            HttpContext.Request.Cookies.TryGetValue(SecurityConstants.REFRESH_TOKEN_NAME, out refreshToken);

            var hasRefreshToken = !string.IsNullOrWhiteSpace(refreshToken);
            if (!hasRefreshToken)
                return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.NO_REFRESH_TOKEN_MSG));

            var isRefreshTokenValid = await _authService.ValidateToken(refreshToken);
            if (isRefreshTokenValid)
            {
                var user = await _authService.AuthenticateByTokenAsync(refreshToken);
                if (user != default)
                {
                    SetAccessTokenOnCookies(user);
                    var response = new ResponseBase<AccessTokenOutputVm>(user, message: SecurityMessages.TOKEN_CONCEIVED_MSG);
                    return Ok(response);
                }
                else
                    return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.USER_DOES_NOT_EXIST_MSG));

            }
            else
                return ResponseUnsuccessfulResultByInvalidTokenType(_authService.InvalidTokenType);
        }
    }
}
