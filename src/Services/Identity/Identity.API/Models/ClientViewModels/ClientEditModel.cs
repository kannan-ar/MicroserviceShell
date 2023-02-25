using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace Identity.API.Models.ClientViewModels
{
    public class ClientEditModel
    {
        private string postLogoutRedirectUri;

        [Required]
        [Display(Name = "Client ID")]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        public string ClientSecret { get; set; }
        public bool RequireClientSecret { get; set; }

        public string AllowedGrantType 
        { 
            get => AllowedGrantTypes == null ? string.Empty : string.Join(',', AllowedGrantTypes); 
            set => AllowedGrantTypes = value?.Split(','); 
        }

        public string RedirectUri 
        { 
            get => RedirectUris == null ? string.Empty : string.Join(',', RedirectUris); 
            set => RedirectUris = value?.Split(','); 
        }

        public string PostLogoutRedirectUri 
        { 
            get => PostLogoutRedirectUris == null ? string.Empty : string.Join(',', PostLogoutRedirectUris); 
            set => PostLogoutRedirectUris = value?.Split(','); 
        }

        public string AllowedScopesString 
        { 
            get => AllowedScopes == null ? string.Empty : string.Join(',', AllowedScopes); 
            set => AllowedScopes = value?.Split(','); 
        }


        public string AllowedCorsOrigin 
        { 
            get => AllowedCorsOrigins == null ? string.Empty : string.Join(',', AllowedCorsOrigins); 
            set => AllowedCorsOrigins = value?.Split(','); 
        }

        public ICollection<string> AllowedGrantTypes
        {
            get; set;
        }

        public ICollection<string> RedirectUris
        {
            get; set;
        }

        public ICollection<string> PostLogoutRedirectUris
        {
            get; set;
        }

        public ICollection<string> AllowedScopes
        {
            get; set;
        }

        public ICollection<string> AllowedCorsOrigins
        {
            get; set;
        }
    }
}
