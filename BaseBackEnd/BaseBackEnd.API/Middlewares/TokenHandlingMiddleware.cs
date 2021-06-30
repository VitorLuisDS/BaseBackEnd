using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Constants.Messages;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task Invoke(HttpContext context, [FromServices] ITokenService tokenService)
        {
            await ValidateAccessTokenAsync(context, tokenService);

            await next(context);
        }

        private async Task ValidateAccessTokenAsync(HttpContext context, ITokenService tokenService)
        {
            var hasAccessToken = context.Request.Headers.Any(i => i.Key.Equals("Authorization") && i.Value.Count > 0);
            if (hasAccessToken)
            {
                var headerAccessToken = context.Request.Headers.FirstOrDefault(i => i.Key.Equals("Authorization")).Value[0];
                var accessTokenValid = await tokenService.ValidateToken(headerAccessToken);
                if (!accessTokenValid)
                {
                    switch (tokenService.InvalidTokenType)
                    {
                        case InvalidTokenType.Expired:
                            await WriteAndCompleteWithMessageAsync(context, HttpStatusCode.Forbidden, SecurityMessages.EXPIRED_TOKEN_MSG);
                            break;
                        case InvalidTokenType.Blacklisted:
                            await WriteAndCompleteWithMessageAsync(context, HttpStatusCode.Unauthorized, SecurityMessages.BLACKLISTED_TOKEN_MSG);
                            break;
                        case InvalidTokenType.Other:
                        default:
                            await WriteAndCompleteWithMessageAsync(context, HttpStatusCode.Unauthorized, SecurityMessages.INVALID_TOKEN_MSG);
                            break;
                    }
                }
            }
        }

        private async Task WriteAndCompleteWithMessageAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(new ResponseBase((HttpStatusCode)context.Response.StatusCode, message));
            await context.Response.CompleteAsync();
        }
    }
}
