using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;

namespace Identity.API.Data
{
    public class ConfigurationDbContextSeed
    {
        public async Task SeedAsync(ConfigurationDbContext context)
        {
            if(!context.IdentityResources.Any())
            {
                context.IdentityResources.Add(new IdentityResources.OpenId().ToEntity());
                context.IdentityResources.Add(new IdentityResources.Profile().ToEntity());

                await context.SaveChangesAsync();
            }

            if(!context.ApiScopes.Any())
            {
                context.ApiScopes.Add(new ApiScope("api1", "api1").ToEntity());
                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                context.ApiResources.Add(new ApiResource("api1", "My API #1").ToEntity());

                await context.SaveChangesAsync();
            }

            if(!context.Clients.Any())
            {
                context.Clients.Add(new Client
                {
                    ClientId = "pkce_client",
                    ClientName = "MVC PKCE Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("acf2ec6fb01a4b698ba240c2b10a0243".Sha256()) },
                    RedirectUris = { "http://host.docker.internal:8003/signin-oidc" },
                    AllowedScopes = { "openid", "profile", "api1" },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }.ToEntity());

                await context.SaveChangesAsync();
            }
        }
    }
}
