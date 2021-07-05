using BaseBackEnd.API.Constants.Messages;
using BaseBackEnd.API.Models;
using BaseBackEnd.API.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;

namespace BaseBackEnd.API.Configs
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
