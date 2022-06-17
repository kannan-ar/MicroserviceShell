using AutoMapper;
using Shell.API.Data;
using Shell.API.Models.DTOs;
using Shell.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shell.API.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IMapper _mapper;
        private readonly IDbRepository<Models.Entities.PageMetaData> _repository;

        public PageService(IMapper mapper, IDbRepository<Models.Entities.PageMetaData> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task AddPage(Models.Entities.PageMetaData metaData)
        {
            await _repository.Add(_mapper.Map<Models.Entities.PageMetaData>(metaData));
        }

        public async Task<IEnumerable<Models.Entities.PageMetaData>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
