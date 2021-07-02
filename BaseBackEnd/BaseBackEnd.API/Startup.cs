using BaseBackEnd.API.Helpers;
using BaseBackEnd.API.Middlewares;
using BaseBackEnd.Domain.Config;
using BaseBackEnd.Domain.Constants.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Domain.Service.Services.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Security;
using BaseBackEnd.Infrastructure.Data.UnityOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            ConfigureAccessToken(services);
            services.Configure<TokenConfig>(Configuration.GetSection("TokenConfiguration"));
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaseBackEnd.API v1"));
            }

            app.UseCors(AuthConstants.POLICY_DEFAULT_NAME);

            app.UseMiddleware(typeof(ExceptionMiddleware));

            app.UseMiddleware(typeof(TokenHandlingMiddleware));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UpdateDatabase(app);
        }

        private void ConfigureAccessToken(IServiceCollection services)
        {
            var tokenConfiguration = new TokenConfig();

            new ConfigureFromConfigurationOptions<TokenConfig>(Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;

                paramsValidation.ValidateIssuerSigningKey = true;

                paramsValidation.ValidateLifetime = true;

                paramsValidation.ValidateIssuer = true;

                paramsValidation.ValidateAudience = false;

                paramsValidation.ValidIssuers = tokenConfiguration.ValidIssuers;

                paramsValidation.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfiguration.Secret));

                paramsValidation.ClockSkew = TimeSpan.Zero;

                bearerOptions.Events = new JwtBearerEvents
                {
                    OnChallenge = ValidateTokensBeforeAuthorizeAttribute()
                };
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(AuthConstants.AUTHENTICATION_HEADER_TYPE.Trim(), new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
            });
        }

        private static Func<JwtBearerChallengeContext, Task> ValidateTokensBeforeAuthorizeAttribute()
        {
            return async context =>
            {
                var refreshToken = context.HttpContext.Request.GetCookieValue(AuthConstants.REFRESH_TOKEN_NAME);
                var hasRefreshToken = !string.IsNullOrWhiteSpace(refreshToken);
                if (!hasRefreshToken)
                {
                    await context.HttpContext.Response.WriteAndCompleteJsonAsync(TokenType.RefreshToken, InvalidTokenType.NotProvided);
                }

                var hasAccessToken = context.HttpContext.Request.Headers.Authorization.Any();
                if (!hasAccessToken)
                {
                    await context.HttpContext.Response.WriteAndCompleteJsonAsync(TokenType.AccessToken, InvalidTokenType.NotProvided);
                }
            };
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
            services.AddScoped<Domain.Interfaces.Service.Security.IAuthorizationService, AuthorizationService>();
        }

    }
}
