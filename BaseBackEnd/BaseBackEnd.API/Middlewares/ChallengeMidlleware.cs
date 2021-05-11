using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Middlewares
{
    public class ChallengeMidlleware
    {
        private readonly RequestDelegate requestDelegate;

        public ChallengeMidlleware(RequestDelegate requestDelegate)
        {
            if (requestDelegate == null)
                throw new ArgumentNullException(nameof(requestDelegate), nameof(requestDelegate) + " é requerido");

            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string msg = "Não autorizado";

            if (context == null)
                throw new ArgumentNullException(nameof(context), nameof(context) + " é requerido");

            var oldStatusCode = context.Response.StatusCode;

            if (context.Response.StatusCode == StatusCodes.Status403Forbidden || context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                if (oldStatusCode == StatusCodes.Status403Forbidden)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    msg = "Sessão Expirada";
                }

                await HandleExceptionAsync(context, msg);
            }

            await requestDelegate(context);
        }

        private static Task HandleExceptionAsync(HttpContext context, string message)
        {
            var result = JsonConvert.SerializeObject(new { message });
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
