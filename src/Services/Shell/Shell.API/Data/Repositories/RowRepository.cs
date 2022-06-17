using AutoMapper;
using Shell.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shell.API.Models.Entities;
using Shell.API.Data.Entities;

namespace Shell.API.Data.Repositories
{
    public class RowRepository : MongoDbRepository, IDbRepository<Models.Entities.Row>
    {
        private readonly IMapper _mapper;

        public RowRepository(IMongoClient client, IMapper mapper, IOptions<MongoDbSettings> mongoDbSettings)
            : base(client, mongoDbSettings)
        {
            _mapper = mapper;
        }

        protected override string CollectionName => "rows";

        public async Task Add(Models.Entities.Row entity)
        {
            await InsertAsync(_mapper.Map<Entities.Row>(entity));
        }

        public async Task<IEnumerable<Models.Entities.Row>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Models.Entities.Row>>(await GetQueryable<Entities.Row>().ToListAsync());
        }
    }
}
