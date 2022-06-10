using AutoMapper;
using DbEntites = Shell.API.Data.Entities;
using Entities = Shell.API.Models.Entities;

namespace Shell.API.Profiles
{
    public class BackendProfile : Profile
    {
        public BackendProfile()
        {
            CreateMap<DbEntites.Row, Entities.Row>().ReverseMap();
        }
    }
}
