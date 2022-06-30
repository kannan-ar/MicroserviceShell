using AutoMapper;
using Shell.API.Core.Repositories;
using Shell.API.Core.Services;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IMapper _mapper;
        private readonly IPageRepository _repository;

        public PageService(IMapper mapper, IPageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task InsertPage(PageMetaData metaData)
        {
            await _repository.InsertAsync(_mapper.Map<PageMetaData>(metaData));
        }

        public async Task<IEnumerable<PageMetaData>> GetPagesAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<PageMetaData> GetPageAsync(string pageName)
        {
            return await _repository.GetPage(pageName);
        }

        public async Task<bool> IsPageExists(string pageName)
        {
            return (await _repository.GetPage(pageName)) != null;
        }

        public async Task UpsertPage(string pageName, PageMetaData metaData)
        {
            await _repository.InsertOrUpdatePageAsync(pageName, metaData);
        }

        public async Task<PageMetaData> UpdatePage(string pageName, PageMetaData metaData)
        {
            return await _repository.UpdatePageAsync(pageName, metaData);
        }

        public async Task DeletePage(string pageName)
        {
            await _repository.DeletePageAsync(pageName);
        }
    }
}
