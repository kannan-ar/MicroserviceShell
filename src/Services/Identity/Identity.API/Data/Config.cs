using IdentityServer4.Models;

namespace Identity.API.Data
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "pkce_client",
                    ClientName = "MVC PKCE Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = {new Secret("acf2ec6fb01a4b698ba240c2b10a0243".Sha256())},
                    RedirectUris = { "http://host.docker.internal:8003/signin-oidc" },
                    AllowedScopes = {"openid", "profile", "api1"},
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }

        public static IEnumerable<ApiScope> Scopes
        {
            get
            {
                return new List<ApiScope>
                {
                    new ApiScope("api1", "api1")
                };
            }
        }
    }
}
