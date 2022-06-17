using AutoMapper;

namespace Shell.API.Profiles
{
    public class BackendProfile : Profile
    {
        public BackendProfile()
        {
            CreateMap<Data.Entities.Row, Models.Entities.Row>().ReverseMap();
            CreateMap<Data.Entities.PageInfo, Models.Entities.PageMetaData>().ReverseMap();
        }
    }
}
