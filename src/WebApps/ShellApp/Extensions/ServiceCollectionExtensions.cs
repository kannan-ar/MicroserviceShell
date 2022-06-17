using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ShellApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //https://stackoverflow.com/questions/65365920/addopenidconnect-middleware-clarification/65369709#65369709
        //https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/introduction?view=aspnetcore-5.0
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime);
            })
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                //https://connect2id.com/learn/openid-connect
                var identityUrl = configuration.GetValue<string>("IdentityUrl");
                var callBackUrl = configuration.GetValue<string>("CallBackUrl");

                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.ClientId = configuration.GetValue<string>("ClientId");
                options.ClientSecret = configuration.GetValue<string>("ClientSecret");
                options.ResponseType = "code";
                options.SignedOutRedirectUri = callBackUrl;
                options.Scope.Add(configuration.GetValue<string>("Scope"));
                options.UsePkce = true;
                options.SaveTokens = true;
            });

            return services;
        }
    }
}
