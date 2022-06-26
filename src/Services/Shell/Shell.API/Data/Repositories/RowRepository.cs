using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shell.API.Core.Repositories;
using Shell.API.Models;
using System.Threading.Tasks;

namespace Shell.API.Data.Repositories
{
    public class RowRepository : MongoDbRepository<Models.Entities.Row, Entities.Row>, IRowRepository
    {
        public RowRepository(IMongoClient client, IMapper mapper, IOptions<MongoDbSettings> mongoDbSettings)
            : base(mapper, client, mongoDbSettings)
        {
        }

        protected override string CollectionName => "rows";
    }
}
