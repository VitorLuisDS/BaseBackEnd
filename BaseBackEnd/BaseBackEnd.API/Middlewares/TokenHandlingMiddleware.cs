using BaseBackEnd.Security.API.Constants.Security;
using BaseBackEnd.Security.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.API.Middlewares
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
                    await context.Response.WriteAndCompleteUnauthorizedJsonAsync(TokenType.AccessToken, tokenService.InvalidTokenType);
                }
            }
        }
    }
}
