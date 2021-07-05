using BaseBackEnd.API.Constants.Security;
using Microsoft.Extensions.DependencyInjection;

namespace BaseBackEnd.API.Configs
{
    public static class CorsConfig
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: AuthConstants.POLICY_DEFAULT_NAME,
                     builder =>
                     {
                         builder
                             .SetIsOriginAllowedToAllowWildcardSubdomains()
                             .AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod();

                         builder
                         .WithOrigins("http://localhost:8080/")
                         .AllowAnyHeader()
                         .AllowAnyMethod()
                         .AllowCredentials()
                         .SetIsOriginAllowed(origin => true);
                     });
            });
        }
    }
}
