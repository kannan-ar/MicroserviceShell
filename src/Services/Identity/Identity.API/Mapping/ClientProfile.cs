using AutoMapper;
using Identity.API.Models.ClientViewModels;
using IdentityServer4.Models;

namespace Identity.API.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientViewModel, Client>().ReverseMap();
            CreateMap<RegisterViewModel, Client>().ReverseMap();
            CreateMap<Client, ClientDetailModel>();
            CreateMap<Client, ClientEditModel>().ReverseMap();
        }
    }
}
