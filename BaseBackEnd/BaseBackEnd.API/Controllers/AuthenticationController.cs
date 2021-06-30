using BaseBackEnd.API.Constants.Endpoints;
using BaseBackEnd.API.Models.Attributes;
using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Constants.Messages;
using BaseBackEnd.Domain.Constants.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Controllers
{
    [Route(AuthenticationEndpoints.BASE_ENDPOINT)]
    [ApiController]
    public class AuthenticationController : ControllerBaseBackEnd
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        public AuthenticationController(IAuthenticationService authService, ITokenService tokenService)
        {
            _authenticationService = authService;
            _tokenService = tokenService;
        }

        [HttpPost(AuthenticationEndpoints.AUTHENTICATE)]
        [ProducesBase(typeof(ResponseBase<AccessTokenOutputVm>))]
        [ProducesResponseTypeBase(typeof(ResponseBase), HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthInputVm userAuthInputVm)
        {
            var newTokens = await _authenticationService.AuthenticateAsync(userAuthInputVm);
            if (newTokens != default)
            {
                SetAccessTokenOnCookies(newTokens);
                var response = new ResponseBase<AccessTokenOutputVm>(newTokens, message: SecurityMessages.USER_AUTHENTICATED_MSG);
                return Ok(response);
            }
            else
                return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.INVALI_USER_OR_PASSWORD));
        }

        [HttpPost(AuthenticationEndpoints.RENEW_ACCESS_TOKEN)]
        [ProducesBase(typeof(ResponseBase<AccessTokenOutputVm>))]
        [ProducesResponseTypeBase(HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> RenewAccessToken()
        {
            string refreshToken;
            HttpContext.Request.Cookies.TryGetValue(AuthConstants.REFRESH_TOKEN_NAME, out refreshToken);

            var hasRefreshToken = !string.IsNullOrWhiteSpace(refreshToken);
            if (!hasRefreshToken)
                return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.NO_REFRESH_TOKEN_MSG));

            var isRefreshTokenValid = await _tokenService.ValidateToken(refreshToken);
            if (isRefreshTokenValid)
            {
                var newTokens = await _authenticationService.AuthenticateByTokenAsync(refreshToken);
                if (newTokens != default)
                {
                    SetAccessTokenOnCookies(newTokens);
                    var response = new ResponseBase<AccessTokenOutputVm>(newTokens, message: SecurityMessages.TOKEN_CONCEIVED_MSG);
                    return Ok(response);
                }
                else
                    return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.INVALI_USER_OR_PASSWORD));

            }
            else
                return ResponseUnsuccessfulResultByInvalidTokenType(_authenticationService.InvalidTokenType);
        }
    }
}
