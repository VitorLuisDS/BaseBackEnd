using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BaseBackEnd.Security.API.Configs
{
    public static class ValidatorConfig
    {
        public static IMvcBuilder AddAndConfigureFluentValidation(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<UserAuthInputVmValidator>();
                });
        }
    }
}
