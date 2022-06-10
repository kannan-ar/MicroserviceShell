using AutoMapper;
using DTOs = Shell.API.Models.DTOs;
using Entities = Shell.API.Models.Entities;

namespace Shell.API.Profiles
{
    public class FrontendProfile : Profile
    {
        public FrontendProfile()
        {
            CreateMap<DTOs.Row, Entities.Row>().ReverseMap();
        }
    }
}
