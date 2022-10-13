using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Data
{
    public class ConfigurationDbContextSeed
    {
        public async Task SeedAsync(ConfigurationDbContext context)
        {
            if (!context.IdentityResources.Any())
            {
                context.IdentityResources.Add(new IdentityResources.OpenId().ToEntity());
                context.IdentityResources.Add(new IdentityResources.Profile().ToEntity());

                await context.SaveChangesAsync();
            }

            if (!context.ApiScopes.Any())
            {
                context.ApiScopes.Add(new ApiScope("mfscope", "Microfrontend API").ToEntity());
                context.ApiScopes.Add(new ApiScope("shellappscope", "Shell App").ToEntity());
                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                context.ApiResources.Add(new ApiResource("mfapiresource", "Microfrontend API")
                {
                    Scopes = { "mfscope" }
                }.ToEntity());

                context.ApiResources.Add(new ApiResource("shellappresource", "Shell App")
                {
                    Scopes = { "shellappscope", "mfscope" }
                }.ToEntity());

                await context.SaveChangesAsync();
            }

            if (!context.Clients.Any())
            {
                context.Clients.Add(new Client
                {
                    ClientId = "shellapp",
                    ClientName = "shellapp",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>
                    {
                        "http://host.docker.internal:8003/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://host.docker.internal:8003/signout-callback-oidc"
                    },
                    ClientSecrets =
                    {
                        new Secret("acf2ec6fb01a4b698ba240c2b10a0243".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "profile",
                        "shellappscope"
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }.ToEntity());

                context.Clients.Add(new Client
                {
                    ClientId = "mfswaggerui",
                    ClientName = "Swagger UI for Microfrontend",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "http://host.docker.internal:8002/swagger/oauth2-redirect.html"
                    },
                    AllowedScopes = new List<string>
                    {
                        "mfscope"
                    },
                    RequireConsent = false
                }.ToEntity());

                await context.SaveChangesAsync();
            }
        }
    }
}
