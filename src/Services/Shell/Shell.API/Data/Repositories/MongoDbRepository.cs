using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Shell.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Data.Repositories
{
    public abstract class MongoDbRepository<TModel, TData>
        where TModel : class
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        protected MongoDbRepository(IMapper mapper, IMongoClient client, IOptions<MongoDbSettings> mongoDbSettings)
        {
            _mapper = mapper;
            _database = client.GetDatabase(mongoDbSettings.Value.DbName);
        }

        protected abstract string CollectionName { get; }

        private IMongoCollection<TData> GetCollection()
        {
            return _database.GetCollection<TData>(CollectionName);
        }
       
        public async Task InsertAsync(TModel entity)
        {
            await GetCollection().InsertOneAsync(_mapper.Map<TModel, TData>(entity));
        }

        public async Task<IEnumerable<TModel>> GetAsync()
        {
            return _mapper.Map<IEnumerable<TModel>>(await GetCollection().AsQueryable().ToListAsync());
        }

        public async Task<IEnumerable<TModel>> GetAsync(FilterDefinition<TData> filter)
        {
            return _mapper.Map<IEnumerable<TModel>>(await GetCollection().Find(filter).ToListAsync());
        }

        public async Task<TModel> GetFirstOrDefaultAsync(FilterDefinition<TData> filter)
        {
            return _mapper.Map<TModel>(await GetCollection().Find(filter).FirstOrDefaultAsync());
        }

        public async Task InsertOrReplaceAsync(FilterDefinition<TData> filter, TModel data)
        {
            await GetCollection().ReplaceOneAsync(filter, _mapper.Map<TModel, TData>(data), new ReplaceOptions
            {
                IsUpsert = true,
            });
        }

        public async Task<TModel> UpdateAsync(FilterDefinition<TData> filter, UpdateDefinition<TData> entity)
        {
            return _mapper.Map<TModel>(await GetCollection().FindOneAndUpdateAsync(filter, entity));
        }


        public async Task DeleteAsync(FilterDefinition<TData> filter)
        {
            await GetCollection().DeleteManyAsync(filter);
        }
    }
}
