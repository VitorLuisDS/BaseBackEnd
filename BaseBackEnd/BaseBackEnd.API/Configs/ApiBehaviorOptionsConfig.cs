using BaseBackEnd.Security.API.Constants.Messages;
using BaseBackEnd.Security.API.Models;
using BaseBackEnd.Security.API.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;

namespace BaseBackEnd.Security.API.Configs
{
    public static class ApiBehaviorOptionsConfig
    {
        public static void ConfigureApiBehaviorOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    if (context.ModelState.ErrorCount > 0)
                    {
                        var validationErrorResponse = new ValidationErrorResponse
                        {
                            Errors = context
                                .ModelState
                                .Values
                                .SelectMany(x => x.Errors)
                                ?.Select(x => x.ErrorMessage)
                                ?.ToArray()
                        };

                        return new BadRequestObjectResult(new ResponseBase<ValidationErrorResponse>
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Message = ValidationErrorMessage.VALIDATION_ERRORS_MSG,
                            Content = validationErrorResponse
                        });
                    }
                    return new BadRequestObjectResult(new ResponseBase(HttpStatusCode.BadRequest, ValidationErrorMessage.VALIDATION_ERRORS_MSG));
                };
            });
        }
    }
}
