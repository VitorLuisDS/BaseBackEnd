using BaseBackEnd.Security.API.Services.Auth;
using BaseBackEnd.Security.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Security.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Security;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.UnityOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BaseBackEnd.Security.API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void ConfugureDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionBlackListRepository, SessionBlackListRepository>();
            services.AddScoped<AuthenticationService>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IModulePageRepository, ModulePageRepository>();
            services.AddScoped<IFunctionalityRepository, FunctionalityRepository>();
            services.AddScoped<IProfileModulePageFunctionalityRepository, ProfileModulePageFunctionalityRepository>();
            services.AddScoped<AuthorizationService>();
        }
    }
}
