using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shell.API.Domain.Repositories;
using Shell.API.Infrastructure.Entities;
using Shell.API.Models;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Shell.API.Infrastructure.Repositories
{
    public class PageRepository : MongoDbRepository<PageMetaData, PageInfo>, IPageRepository
    {
        public PageRepository(IMongoClient client, IMapper mapper, IOptions<MongoDbSettings> mongoDbSettings)
            : base(mapper, client, mongoDbSettings)
        {
        }

        protected override string CollectionName => "pages";

        public async Task<PageMetaData> GetPage(string pageName)
        {
            return await GetFirstOrDefaultAsync(Builders<PageInfo>.Filter.Eq(x => x.PageName, pageName));
        }

        public async Task<IEnumerable<PageMetaData>> GetPagesAsync()
        {
            return await GetAsync();
        }

        public async Task<PageMetaData> InsertOrUpdatePageAsync(string pageName, PageMetaData page)
        {
            return await InsertOrReplaceAsync(Builders<PageInfo>.Filter.Eq(x => x.PageName, pageName), page);
        }

        public async Task<PageMetaData> UpdatePageAsync(string pageName, PageMetaData page)
        {
            return await UpdateAsync(
                Builders<PageInfo>.Filter.Eq(x => x.PageName, pageName),
                Builders<PageInfo>.Update
                    .Set(p => p.Header, page.Header)
                    .Set(p => p.Path, page.Path)
                    .Set(p => p.Footer, page.Footer));
        }

        public async Task DeletePageAsync(string pageName)
        {
            await DeleteAsync(Builders<PageInfo>.Filter.Eq(x => x.PageName, pageName));
        }

    }
}
