using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Identity.API.Models.ClientViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Client ID")]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        public string AllowedGrantType { get; set; }

        [Required]
        public string RedirectUri { get; set; }

        [Required]
        public string PostLogoutRedirectUri { get; set; }

        [Required]
        public string AllowedScopesString { get; set; }

        [IgnoreMap]
        public ICollection<string> RedirectUris
        {
            get
            {
                return RedirectUri.Split(',');
            }
        }

        [IgnoreMap]
        public ICollection<string> PostLogoutRedirectUris
        {
            get
            {
                return PostLogoutRedirectUri.Split(',');
            }
        }

        [IgnoreMap]
        public ICollection<string> AllowedScopes
        {
            get
            {
                return AllowedScopesString.Split(',');
            }
        }

        [IgnoreMap]
        public ICollection<string> AllowedGrantTypes
        {
            get
            {
                return AllowedGrantType.Split(',');
            }
        }
    }
}
