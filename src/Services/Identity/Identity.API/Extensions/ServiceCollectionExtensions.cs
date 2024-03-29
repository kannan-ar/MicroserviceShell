﻿using Identity.API.Models;
using Identity.API.Repositories;
using Identity.API.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;

namespace Identity.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IIdentityServerBuilder AddSigningCredentialBasedOnEnviornment(
            this IIdentityServerBuilder services, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddTransient<ILoginService<ApplicationUser>, EFLoginService>();
        }
    }
}
