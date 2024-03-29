﻿using AutoMapper;
using System.Collections.Generic;

namespace Identity.API.Models.ClientViewModels
{
    public class ClientViewModel
    {
        public string ClientId { get; set; }
        public List<string> RedirectUris { get; set; }
        public List<string> PostLogoutRedirectUris { get; set; }
        public List<string> AllowedCorsOrigins { get; set; }
        public List<string> AllowedScopes { get; set; }

        [IgnoreMap]
        public string RedirectUri => string.Join(',', RedirectUris);

        [IgnoreMap]
        public string PostLogoutRedirectUri => string.Join(',', PostLogoutRedirectUris);

        [IgnoreMap]
        public string AllowedScope => string.Join(',', AllowedScopes);

        [IgnoreMap]
        public string AllowedCorsOrigin => string.Join(',', AllowedCorsOrigins);
    }
}
