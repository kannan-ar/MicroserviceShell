using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shell.API.Core.Repositories;
using Shell.API.Data.Entities;
using Shell.API.Models;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Data.Repositories
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
            return await GetOneAsync(Builders<PageInfo>.Filter.Eq(x => x.PageName, pageName));
        }

        public async Task<IEnumerable<PageMetaData>> GetPagesAsync()
        {
            return await GetAllAsync();
        }
    }
}
