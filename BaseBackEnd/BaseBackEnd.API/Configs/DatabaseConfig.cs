using BaseBackEnd.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaseBackEnd.API.Configs
{
    public static class DatabaseConfig
    {
        private static readonly string DEFAULT_DB_CONNECTION = "DefaultConnection";

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            if (Convert.ToBoolean(configuration.GetSection("UseSqlServer").Value))
            {
                services.AddDbContext<ProjectBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString(DEFAULT_DB_CONNECTION)), ServiceLifetime.Scoped);
            }
            else
            {
                services.AddDbContext<ProjectBaseContext>(options => options.UseInMemoryDatabase("KDS_CORE"));
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
                    if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
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
