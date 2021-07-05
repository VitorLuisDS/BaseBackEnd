using BaseBackEnd.API.Constants;
using BaseBackEnd.API.Helpers;
using BaseBackEnd.Domain.Config;
using BaseBackEnd.Domain.Constants.Security;
using BaseBackEnd.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Configs
{
    public static class TokensConfig
    {
        public static void ConfigureTokens(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfiguration = new TokenConfig();

            new ConfigureFromConfigurationOptions<TokenConfig>(configuration.GetSection(AppSettingsConstants.TokenConfigurationSection)).Configure(tokenConfiguration);

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

            services.Configure<TokenConfig>(configuration.GetSection(AppSettingsConstants.TokenConfigurationSection));
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

    }
}
