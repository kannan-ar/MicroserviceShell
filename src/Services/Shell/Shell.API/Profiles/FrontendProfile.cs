using AutoMapper;

using DTOs = Shell.API.Models.DTOs;
using Entities = Shell.API.Models.Entities;

namespace Shell.API.Profiles
{
    public class FrontendProfile : Profile
    {
        public FrontendProfile()
        {
            CreateMap<DTOs.Column, Entities.Column>().ReverseMap();
            CreateMap<DTOs.Row, Entities.Row>().ReverseMap();
            CreateMap<DTOs.PageMetaData, Entities.PageMetaData>().ReverseMap();

            CreateMap<DTOs.ComponentBase, Entities.Component>().ReverseMap();
            CreateMap<DTOs.Component, Entities.Component>().ReverseMap();

        }
    }
}
