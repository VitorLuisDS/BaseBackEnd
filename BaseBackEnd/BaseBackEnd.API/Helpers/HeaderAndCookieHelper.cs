using BaseBackEnd.API.Constants.Security;
using BaseBackEnd.Domain.ViewModel.SecutityVms.TokenVms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace BaseBackEnd.API.Helpers
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
