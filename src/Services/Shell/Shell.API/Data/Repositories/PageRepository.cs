using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shell.API.Data.Entities;
using Shell.API.Models;
using Shell.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Data.Repositories
{
    public class PageRepository : MongoDbRepository, IDbRepository<PageMetaData>
    {
        private readonly IMapper _mapper;

        public PageRepository(IMongoClient client, IMapper mapper, IOptions<MongoDbSettings> mongoDbSettings)
            : base(client, mongoDbSettings)
        {
            _mapper = mapper;
        }

        protected override string CollectionName => "pages";

        public async Task Add(PageMetaData entity)
        {
            await InsertAsync(_mapper.Map<PageInfo>(entity));
        }

        public async Task<IEnumerable<PageMetaData>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PageMetaData>>(await GetQueryable<PageInfo>().ToListAsync().ConfigureAwait(false));
        }
    }
}
