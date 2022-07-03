using AutoMapper;

namespace Shell.API.Profiles
{
    public class BackendProfile : Profile
    {
        public BackendProfile()
        {
            CreateMap<Infrastructure.Entities.Column, Models.Entities.Column>().ReverseMap();
            CreateMap<Infrastructure.Entities.Row, Models.Entities.Row>().ReverseMap();
            CreateMap<Infrastructure.Entities.PageInfo, Models.Entities.PageMetaData>().ReverseMap();
        }
    }
}
