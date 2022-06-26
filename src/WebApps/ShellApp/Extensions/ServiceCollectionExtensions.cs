using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Refit;
using ShellApp.API;
using ShellApp.Core.Services;
using ShellApp.Services;
using System;
using System.Net.Http;

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

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            //https://anthonygiretti.com/2019/03/26/best-practices-with-httpclient-and-retry-policies-with-polly-in-net-core-2-part-1/
            //https://anthonygiretti.com/2019/08/31/building-a-typed-httpclient-with-refit-in-asp-net-core-3/

            services.AddRefitClient<IPageApi>()
            .ConfigureHttpClient(x => x.BaseAddress = new Uri(configuration["PageServiceUrl"]))
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy())
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            services.AddSingleton<IPageService, PageService>();

            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }
    }
}
