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
            var hasAccessToken = context.Request.Headers.Any(i => i.Key.Equals("Authorization"));
            if (hasAccessToken)
            {
                var headerAccessToken = context.Request.Headers.FirstOrDefault(i => i.Key.Equals("Authorization")).Value[0];
                var accessTokenValid = authService.ValidateToken(headerAccessToken);
                if (!accessTokenValid)
                {
                    if (authService.ValidationExceptionType is SecurityTokenExpiredException)
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;

                    var hasRefreshToken = context.Request.Cookies.Any(i => i.Key.Equals(SecurityConstants.REFRESH_TOKEN_NAME));

                    if (authService.ValidationExceptionType is SecurityTokenExpiredException && hasRefreshToken)
                    {
                        string refreshToken = context.Request.Cookies.FirstOrDefault(i => i.Key.Equals(SecurityConstants.REFRESH_TOKEN_NAME)).Value;

                        if (!string.IsNullOrEmpty(refreshToken))
                        {
                            var isRefreshTokenValid = authService.ValidateToken(refreshToken);
                            if (isRefreshTokenValid)
                            {
                                var autenticarPorToken = await authService.AuthenticateByTokenAsync(refreshToken);

                                if (autenticarPorToken != null)
                                {
                                    if (autenticarPorToken != null)
                                    {
                                        context.Request.Headers.Remove("Authorization");
                                        context.Request.Headers.Add("Authorization", $"Bearer {autenticarPorToken.AccessToken}");
                                        context.Response.Headers.Add(SecurityConstants.NEW_TOKEN_NAME, autenticarPorToken.AccessToken);
                                        context.Response.StatusCode = StatusCodes.Status200OK;
                                    }
                                }
                            }
                            else
                            {
                                if (authService.ValidationExceptionType is SecurityTokenExpiredException)
                                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                                else
                                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                await context.Response.WriteAsJsonAsync(new ResponseBase((HttpStatusCode)context.Response.StatusCode, authService.ValidationExceptionType.Message));
                                await context.Response.CompleteAsync();
                            }
                        }
                    }
                    else if (!hasRefreshToken)
                    {
                        await context.Response.WriteAsJsonAsync(new ResponseBase(message: authService.ValidationExceptionType.Message + " and no refresh token provided"));
                        await context.Response.CompleteAsync();
                    }
                }
            }

            await next(context);
        }
    }
}
