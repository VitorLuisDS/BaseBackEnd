using BaseBackEnd.API.Constants.Security;
using BaseBackEnd.API.Helpers;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task Invoke(HttpContext context, [FromServices] ITokenService tokenService)
        {
            await ValidateAccessTokenAsync(context, tokenService);

            await next(context);
        }

        private async Task ValidateAccessTokenAsync(HttpContext context, ITokenService tokenService)
        {
            var hasAccessToken = context.Request.Headers.Authorization.Any();
            if (hasAccessToken)
            {
                var headerAccessToken = context.Request.Headers.Authorization.First();
                if (headerAccessToken.StartsWith(AuthConstants.AUTHENTICATION_HEADER_TYPE))
                    headerAccessToken = headerAccessToken.Substring(7);

                var accessTokenValid = await tokenService.ValidateToken(headerAccessToken);
                if (!accessTokenValid)
                {
                    await context.Response.WriteAndCompleteJsonAsync(TokenType.AccessToken, tokenService.InvalidTokenType);
                }
            }
        }
    }
}
