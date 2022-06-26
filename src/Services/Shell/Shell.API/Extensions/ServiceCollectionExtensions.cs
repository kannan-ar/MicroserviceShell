using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Shell.API.Core.Repositories;
using Shell.API.Core.Services;
using Shell.API.Data.Repositories;
using Shell.API.Filters;
using Shell.API.Models;
using Shell.API.Services.Implementations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace Shell.API.Extensions
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
                options.Audience = configuration.GetValue<string>("IdentityAudience");
            });
        }

        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
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
                                { "mfscope", "Microfrontend API" }
                            }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

        }

        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MongoDbSettings:ConnectionString"];

            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
        }

        public static void AddEntityMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRowRepository, RowRepository>();
            services.AddSingleton<IPageRepository, PageRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IRowService, RowService>();
            services.AddSingleton<IPageService, PageService>();
        }
    }
}
