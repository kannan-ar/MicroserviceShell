using AutoMapper;

using DbEntities = Shell.API.Infrastructure.Entities;
using Entities = Shell.API.Models.Entities;

namespace Shell.API.Profiles
{
    public class BackendProfile : Profile
    {
        public BackendProfile()
        {
            CreateMap<DbEntities.Column, Entities.Column>().ReverseMap();
            CreateMap<DbEntities.Row, Entities.Row>().ReverseMap();
            CreateMap<DbEntities.PageInfo, Entities.PageMetaData>().ReverseMap();

            CreateMap<DbEntities.Component, Entities.Component>().ReverseMap();
        }
    }
}
