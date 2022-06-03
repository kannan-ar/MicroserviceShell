using AutoMapper;
using MicroFrontend.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroFrontend.API.Data.Repositories
{
    public class RowRepository : MongoDbRepository, IDbRepository<Models.Entities.Row>
    {
        private readonly IMapper _mapper;

        public RowRepository(IMongoClient client, IMapper mapper, IOptions<MongoDbSettings> mongoDbSettings)
            : base(client, mongoDbSettings)
        {
            _mapper = mapper;
        }

        public async Task Add(Models.Entities.Row entity)
        {
            await InsertAsync(_mapper.Map<MongoDb.Entities.Row>(entity));
        }

        public async Task<IEnumerable<Models.Entities.Row>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Models.Entities.Row>>(await GetQueryable<MongoDb.Entities.Row>().ToListAsync());
        }
    }
}
