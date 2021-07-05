using BaseBackEnd.API.Configs;
using BaseBackEnd.API.Constants.Security;
using BaseBackEnd.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace BaseBackEnd.API
{
    public class Startup
    {
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
                .AddAndConfigureFluentValidation()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            services.ConfigureApiBehaviorOptions();

            services.ConfugureDependencyInjections();

            services.ConfigureDatabase(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaseBackEnd.API", Version = "v1" });
            });

            services.AddHttpContextAccessor();

            services.ConfigureTokens(Configuration);

            services.ConfigureCors();
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

            DatabaseConfig.UpdateDatabase(app);
        }
    }
}
