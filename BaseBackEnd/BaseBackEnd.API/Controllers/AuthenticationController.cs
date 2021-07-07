﻿using BaseBackEnd.Security.API.Constants.Endpoints;
using BaseBackEnd.Security.API.Constants.Messages;
using BaseBackEnd.Security.API.Constants.Security;
using BaseBackEnd.Security.API.Helpers;
using BaseBackEnd.Security.API.Models.Attributes;
using BaseBackEnd.Security.API.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.API.Controllers
{
    [Route(AuthenticationEndpoints.BASE_ENDPOINT)]
    [ApiController]
    public class AuthenticationController : ControllerBaseBackEnd
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        public AuthenticationController(IAuthenticationService authService, ITokenService tokenService) : base(authService)
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
                HttpContext.Response.SetAccessTokenOnCookies(newTokens);
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
            var refreshToken = HttpContext.Request.GetCookieValue(AuthConstants.REFRESH_TOKEN_NAME);
            var hasRefreshToken = !string.IsNullOrWhiteSpace(refreshToken);
            if (!hasRefreshToken)
                return UnauthorizedResponseByInvalidTokenType(TokenType.RefreshToken, InvalidTokenType.NotProvided);

            var isRefreshTokenValid = await _tokenService.ValidateToken(refreshToken);
            if (isRefreshTokenValid)
            {
                var newTokens = await _authenticationService.AuthenticateByTokenAsync(refreshToken);
                if (newTokens != default)
                {
                    HttpContext.Response.SetAccessTokenOnCookies(newTokens);
                    var response = new ResponseBase<AccessTokenOutputVm>(newTokens, message: SecurityMessages.TOKEN_CONCEIVED_MSG);
                    return Ok(response);
                }
                else
                    return UnauthorizedResponseByInvalidTokenType(TokenType.RefreshToken, InvalidTokenType.Other);

            }
            else
                return UnauthorizedResponseByInvalidTokenType(TokenType.RefreshToken, _authenticationService.InvalidTokenType);
        }
    }
}
