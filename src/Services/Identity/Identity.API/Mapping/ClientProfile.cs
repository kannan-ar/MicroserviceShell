using AutoMapper;
using Identity.API.Models.ClientViewModels;
using IdentityServer4.Models;

namespace Identity.API.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<RegisterViewModel, Client>();
            CreateMap<Client, ClientViewModel>();
        }
    }
}
