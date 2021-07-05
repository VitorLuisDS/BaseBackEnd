using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Domain.Security;
using BaseBackEnd.Infrastructure.Data.Repository.Security;
using BaseBackEnd.Infrastructure.Data.UnityOfWork;
using BaseBackEnd.Service.Security;
using Microsoft.Extensions.DependencyInjection;

namespace BaseBackEnd.API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void ConfugureDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionBlackListRepository, SessionBlackListRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IModulePageRepository, ModulePageRepository>();
            services.AddScoped<IFunctionalityRepository, FunctionalityRepository>();
            services.AddScoped<IProfileModulePageFunctionalityRepository, ProfileModulePageFunctionalityRepository>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
        }
    }
}
