using BaseBackEnd.Security.API.Constants.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace BaseBackEnd.Security.API.Helpers
{
    public static class HeaderAndCookieHelper
    {
        public static string GetHeaderValue(this HttpRequest httpRequest, string key)
        {
            StringValues value = default;
            httpRequest.Headers.TryGetValue(key, out value);
            return value;
        }

        public static string GetCookieValue(this HttpRequest httpRequest, string key)
        {
            string value = default;
            httpRequest.Cookies.TryGetValue(key, out value);
            return value;
        }

        public static void SetAccessTokenOnCookies(this HttpResponse httpResponse, TokensOutputVm user)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            };

            httpResponse.Cookies.Append(AuthConstants.REFRESH_TOKEN_NAME, user.RefreshToken, cookieOptions);
        }
    }
}
