using IdentityServer4.Models;

namespace Identity.API.Extensions
{
    public static class ClientExtensions
    {
        public static Client Clone(this Client client)
        {
            return new Client
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                ClientSecrets = client.ClientSecrets,
                AllowedGrantTypes = client.AllowedGrantTypes,
                RedirectUris = client.RedirectUris,
                PostLogoutRedirectUris = client.PostLogoutRedirectUris,
                AllowedScopes = client.AllowedScopes,
                AllowedCorsOrigins = client.AllowedCorsOrigins,
            };
        }
    }
}
