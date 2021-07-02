using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Helpers
{
    public static class HeaderAndCookieHelper
    {
        public static string GetHeaderValue(this HttpRequest httpRequest,string key)
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
    }
}
