using MicroFrontend.API.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;

namespace MicroFrontend.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIdentityAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            var identityUrl = configuration.GetValue<string>("IdentityUrl");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "microfrontend";
            });
        }

        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Shell API",
                    Version = "v1",
                    Description = "Shell API"
                });

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{configuration.GetValue<string>("IdentityUrlExternal")}/connect/authorize"),
                            TokenUrl = new Uri($"{configuration.GetValue<string>("IdentityUrlExternal")}/connect/token"),
                            Scopes = new Dictionary<string, string>()
                            {
                                { "microfrontend", "Microfrontend API" }
                            }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

        }
    }
}
