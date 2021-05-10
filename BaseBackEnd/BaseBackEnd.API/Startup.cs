using BaseBackEnd.Domain.Config;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Domain.Service.Services.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Security;
using BaseBackEnd.Infrastructure.Data.UnityOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;

namespace BaseBackEnd.API
{
    public class Startup
    {
        private static readonly string DEFAULT_DB_CONNECTION = "DefaultConnection";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            ConfugureDependencyInjections(services);

            SetupDatabase(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaseBackEnd.API", Version = "v1" });
            });

            services.AddHttpContextAccessor();
            services.Configure<TokenConfig>(Configuration.GetSection("TokenConfiguration"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaseBackEnd.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UpdateDatabase(app);
        }

        protected virtual void SetupDatabase(IServiceCollection services)
        {
            if (Convert.ToBoolean(Configuration.GetSection("UseSqlServer").Value))
            {
                services.AddDbContext<ProjectBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString(DEFAULT_DB_CONNECTION)), ServiceLifetime.Scoped);
            }
            else
            {
                services.AddDbContext<ProjectBaseContext>(options => options.UseInMemoryDatabase("KDS_CORE"));
            }
        }

        private static async void UpdateDatabase(IApplicationBuilder app)
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

        private void ConfugureDependencyInjections(IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IAuthService, AuthService>();
        }

    }
}
