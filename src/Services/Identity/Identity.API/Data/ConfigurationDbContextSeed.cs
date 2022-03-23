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
                context.ApiScopes.Add(new ApiScope("mfscope", "Microfrontend API").ToEntity());
                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                context.ApiResources.Add(new ApiResource("mfapiresource", "Microfrontend API")
                {
                    Scopes = { "mfscope" }
                }.ToEntity());
                
                await context.SaveChangesAsync();
            }
        }
    }
}
