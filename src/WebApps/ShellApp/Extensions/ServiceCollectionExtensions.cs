using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ShellApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //var identityUrl = configuration.GetValue<string>("IdentityUrl");
            //var callBackUrl = configuration.GetValue<string>("CallBackUrl");
            //var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
            //.AddOpenIdConnect(options =>
            //{
            //    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.Authority = identityUrl.ToString();
            //    options.SignedOutRedirectUri = callBackUrl.ToString();
            //    options.ClientId = configuration.GetValue<string>("ClientId");
            //    options.ClientSecret = configuration.GetValue<string>("ClientSecret");
            //    options.ResponseType = "code id_token";
            //    options.SaveTokens = true;
            //    options.GetClaimsFromUserInfoEndpoint = true;
            //    options.RequireHttpsMetadata = false;

            //});

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "cookie";
                options.DefaultSignInScheme = "cookie";
                options.DefaultChallengeScheme = "oidc";
            }).AddCookie("cookie")
            .AddOpenIdConnect("oidc", options =>
            {
                var identityUrl = configuration.GetValue<string>("IdentityUrl");
                var callBackUrl = configuration.GetValue<string>("CallBackUrl");

                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;

                options.ClientId = configuration.GetValue<string>("ClientId");
                options.ClientSecret = configuration.GetValue<string>("ClientSecret");
                options.ResponseType = "code";
                options.SignedOutRedirectUri = callBackUrl;
                options.Scope.Add("api1");
                options.UsePkce = true;
            });

            return services;
        }
    }
}
