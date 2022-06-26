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

        public async Task AddPage(PageMetaData metaData)
        {
            await _repository.InsertAsync(_mapper.Map<PageMetaData>(metaData));
        }

        public async Task<IEnumerable<PageMetaData>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> IsPageExists(string page)
        {
            return (await _repository.GetPage(page)) != null;
        }
    }
}
