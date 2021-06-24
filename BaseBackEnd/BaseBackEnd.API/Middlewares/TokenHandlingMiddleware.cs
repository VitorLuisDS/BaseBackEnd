using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Constants;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Middlewares
{
    public class TokenHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public TokenHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, [FromServices] IAuthService authService)
        {
            var hasAccessToken = context.Request.Headers.Any(i => i.Key.Equals("Authorization") && i.Value.Count > 0);
            if (hasAccessToken)
            {
                var headerAccessToken = context.Request.Headers.FirstOrDefault(i => i.Key.Equals("Authorization")).Value[0];
                var accessTokenValid = authService.ValidateToken(headerAccessToken);
                if (!accessTokenValid && authService.ValidationExceptionType is SecurityTokenExpiredException)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;

                    var hasRefreshToken = context.Request.Cookies.Any(i => i.Key.Equals(SecurityConstants.REFRESH_TOKEN_NAME));
                    if (!hasRefreshToken)
                    {
                        await WriteAndCompleteAsyncWithMessage(context, HttpStatusCode.Unauthorized, authService.ValidationExceptionType.Message + " and no refresh token provided");
                    }
                    else
                    {
                        string refreshToken = context.Request.Cookies.FirstOrDefault(i => i.Key.Equals(SecurityConstants.REFRESH_TOKEN_NAME)).Value;
                        var isRefreshTokenValid = authService.ValidateToken(refreshToken);
                        if (isRefreshTokenValid)
                        {
                            var autenticarPorToken = await authService.AuthenticateByTokenAsync(refreshToken);
                            if (autenticarPorToken != null)
                            {
                                context.Request.Headers.Remove("Authorization");
                                context.Request.Headers.Add("Authorization", $"Bearer {autenticarPorToken.AccessToken}");
                                context.Response.Headers.Add(SecurityConstants.NEW_TOKEN_NAME, autenticarPorToken.AccessToken);
                                context.Response.StatusCode = StatusCodes.Status200OK;
                            }
                        }
                        else
                        {
                            await WriteAndCompleteAsyncWithMessage(context, HttpStatusCode.Unauthorized, authService.ValidationExceptionType.Message);
                        }
                    }
                }
            }

            await next(context);
        }

        private async Task WriteAndCompleteAsyncWithMessage(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(new ResponseBase((HttpStatusCode)context.Response.StatusCode, message));
            await context.Response.CompleteAsync();
        }
    }
}
