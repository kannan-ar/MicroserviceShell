using AutoMapper;
using System.Collections.Generic;

namespace Identity.API.Models.ClientViewModels
{
    public class ClientDetailModel
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public List<string> AllowedGrantTypes { get; set; }
        public List<string> RedirectUris { get; set; }
        public List<string> PostLogoutRedirectUris { get; set; }
        public List<string> AllowedScopes { get; set; }
        public List<string> AllowedCorsOrigins { get; set; }
        public bool RequireClientSecret { get; set; }

        public string RedirectUri => string.Join(',', RedirectUris);

        public string PostLogoutRedirectUri => string.Join(',', PostLogoutRedirectUris);

        public string AllowedScope => string.Join(',', AllowedScopes);

        public string AllowedGrantType => string.Join(',', AllowedGrantTypes);

        public string AllowedCorsOrigin => string.Join(',', AllowedCorsOrigins);

    }
}
