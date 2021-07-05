using BaseBackEnd.API.Constants;
using BaseBackEnd.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseBackEnd.API.Configs
{
    public static class DatabaseConfig
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            bool.TryParse(configuration.GetSection(AppSettingsConstants.UseSqlServerSection).Value, out bool useSqlServer);

            if (useSqlServer)
            {
                var connectionString = configuration.GetSection(AppSettingsConstants.DefaultConnectionStringSection).Value;
                services.AddDbContext<ProjectBaseContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            }
            else
            {
                services.AddDbContext<ProjectBaseContext>(options => options.UseInMemoryDatabase(DatabaseConstants.InMemoryDatabase));
            }
        }

        public static async void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ProjectBaseContext>())
                {
                    if (context.Database.ProviderName != DatabaseConstants.InMemoryDatabaseProvider)
                    {
                        await context.Database.MigrateAsync();
                    }
                    else
                    {
                        //await Seed.SeedImMeoryaAsync(context);
                    }
                }
            }
        }
    }
}
