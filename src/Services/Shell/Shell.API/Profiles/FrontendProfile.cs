using AutoMapper;

namespace Shell.API.Profiles
{
    public class FrontendProfile : Profile
    {
        public FrontendProfile()
        {
            CreateMap<Models.DTOs.Column, Models.Entities.Column>().ReverseMap();
            CreateMap<Models.DTOs.Row, Models.Entities.Row>().ReverseMap();
            CreateMap<Models.DTOs.PageMetaData, Models.Entities.PageMetaData>().ReverseMap();
        }
    }
}
