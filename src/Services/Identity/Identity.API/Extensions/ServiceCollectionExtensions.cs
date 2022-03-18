using Identity.API.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace Identity.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IIdentityServerBuilder AddSigningCredentialBasedOnEnviornment(
            this IIdentityServerBuilder services, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                services.AddDeveloperSigningCredential();
            }
            else
            {
                throw new NotImplementedException();
            }

            return services;
        }

        public static void AddAppInsights(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetry(configuration);
            services.AddApplicationInsightsKubernetesEnricher();
        }

        public static void AddDataProtectionBasedOnConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<string>("IsClusterEnv") == bool.TrueString)
            {
                services.AddDataProtection(opts =>
                {
                    opts.ApplicationDiscriminator = "shell.identity";
                })
                .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(configuration["DPConnectionString"]), "DataProtection-Keys");
            }
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Shell Identity",
                    Version = "v1"
                });
            });
        }
    }
}
