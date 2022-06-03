using AutoMapper;
using DTOs = MicroFrontend.API.Models.DTOs;
using Entities = MicroFrontend.API.Models.Entities;

namespace MicroFrontend.API.Profiles
{
    public class FrontendProfile : Profile
    {
        public FrontendProfile()
        {
            CreateMap<DTOs.Row, Entities.Row>().ReverseMap();
        }
    }
}
