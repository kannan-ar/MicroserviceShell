using AutoMapper;
using DbEntites = MicroFrontend.API.Data.MongoDb.Entities;
using Entities = MicroFrontend.API.Models.Entities;

namespace MicroFrontend.API.Profiles
{
    public class BackendProfile : Profile
    {
        public BackendProfile()
        {
            CreateMap<DbEntites.Row, Entities.Row>().ReverseMap();
        }
    }
}
