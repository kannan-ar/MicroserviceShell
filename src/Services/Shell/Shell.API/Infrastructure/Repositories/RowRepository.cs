﻿using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shell.API.Domain.Repositories;
using Shell.API.Models;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Infrastructure.Repositories
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

        public async Task<Row> UpdateRowAsync(string pageName, int rowIndex, Row row)
        {
            return await UpdateAsync(
                Builders<Entities.Row>.Filter.And(
                    Builders<Entities.Row>.Filter.Eq(x => x.PageName, pageName),
                    Builders<Entities.Row>.Filter.Eq(x => x.RowIndex, rowIndex)),
                Builders<Entities.Row>.Update
                    .Set(p => p.RowIndex, row.RowIndex));
        }

        public async Task InsertOrUpdateRowAsync(string pageName, int rowIndex, Row row)
        {
            await InsertOrReplaceAsync(
               Builders<Entities.Row>.Filter.And(
                   Builders<Entities.Row>.Filter.Eq(x => x.PageName, pageName),
                   Builders<Entities.Row>.Filter.Eq(x => x.RowIndex, rowIndex)), row);
        }

        public async Task DeleteRow(string pageName, int rowIndex)
        {
            await DeleteAsync(Builders<Entities.Row>.Filter.And(
                    Builders<Entities.Row>.Filter.Eq(x => x.PageName, pageName),
                    Builders<Entities.Row>.Filter.Eq(x => x.RowIndex, rowIndex)));
        }

        public async Task<Row> ChangePageNameAsync(string oldPageName, string newPageName)
        {
            return await UpdateAsync(
                Builders<Entities.Row>.Filter.Eq(x => x.PageName, oldPageName),
                Builders<Entities.Row>.Update.Set(p => p.PageName, newPageName));
        }
    }
}
