using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shell.API.Core.Repositories;
using Shell.API.Models;
using Shell.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Data.Repositories
{
    public class RowRepository : MongoDbRepository<Row, Entities.Row>, IRowRepository
    {
        public RowRepository(IMongoClient client, IMapper mapper, IOptions<MongoDbSettings> mongoDbSettings)
            : base(mapper, client, mongoDbSettings)
        {
        }

        protected override string CollectionName => "rows";

        public async Task<IEnumerable<Row>> GetRowsByPageAsync(string pageName)
        {
            return await GetAsync(Builders<Entities.Row>.Filter.Eq(x => x.PageName, pageName));
        }

        public async Task UpdateRow(string pageName, int rowIndex, Row row)
        {
            await UpdateAsync(
                Builders<Entities.Row>.Filter.And(
                    Builders<Entities.Row>.Filter.Eq(x => x.PageName, pageName),
                    Builders<Entities.Row>.Filter.Eq(x => x.RowIndex, rowIndex)),
                Builders<Entities.Row>.Update
                    .Set(p => p.RowIndex, row.RowIndex));
        }
    }
}
