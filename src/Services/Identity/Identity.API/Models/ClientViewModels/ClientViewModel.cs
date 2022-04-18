using AutoMapper;
using System.Linq;

namespace Identity.API.Models.ClientViewModels
{
    public class ClientViewModel
    {
        public string ClientId { get; set; }
        public List<string> RedirectUris { get; set; }
        public List<string> PostLogoutRedirectUris { get; set; }

        [IgnoreMap]
        public string RedirectUri => string.Join(',', RedirectUris);

        [IgnoreMap]
        public string PostLogoutRedirectUri => string.Join(',', PostLogoutRedirectUris);
    }
}
