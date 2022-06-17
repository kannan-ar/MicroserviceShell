using AutoMapper;
using Shell.API.Models.DTOs;
using Shell.API.Models.Entities;

namespace Shell.API.Profiles
{
    public class FrontendProfile : Profile
    {
        public FrontendProfile()
        {
            CreateMap<Models.DTOs.Row, Models.Entities.Row>().ReverseMap();
            CreateMap<Models.DTOs.PageMetaData, Models.Entities.PageMetaData>().ReverseMap();
        }
    }
}
