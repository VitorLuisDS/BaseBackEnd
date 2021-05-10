using BaseBackEnd.Domain.Interfaces.Service.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Linq;
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
            if (context.Request.Headers.Where(i => i.Key.Equals("Authorization")).FirstOrDefault().Value.Count > 0)
            {
                string token = context.Request.Headers.Where(i => i.Key.Equals("Authorization")).FirstOrDefault().Value[0];

                if (!authService.ValidateToken(token))
                {
                    if (authService.ValidationExceptionType is SecurityTokenExpiredException)
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;

                    if (authService.ValidationExceptionType is SecurityTokenExpiredException && context.Request.Headers.Where(i => i.Key.ToLower().Equals("refreshtoken")).FirstOrDefault().Value.Count > 0)
                    {
                        string refreshToken = context.Request.Headers.Where(i => i.Key.Equals("refreshtoken")).FirstOrDefault().Value[0];

                        if (!string.IsNullOrEmpty(refreshToken))
                        {
                            if (authService.ValidateToken(refreshToken))
                            {
                                var autenticarPorToken = await authService.AuthenticateByTokenAsync(refreshToken);

                                if (autenticarPorToken != null)
                                {
                                    if (autenticarPorToken != null)
                                    {
                                        context.Request.Headers.Remove("Authorization");
                                        context.Request.Headers.Add("Authorization", $"Bearer {autenticarPorToken.Token}");
                                        context.Response.Headers.Add("newTokens", JsonConvert.SerializeObject(autenticarPorToken));
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
                            }
                        }
                    }
                }
            }

            await next(context);
        }
    }
}
