﻿using MicroFrontend.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections;

namespace MicroFrontend.API.Data.Repositories
{
    public abstract class MongoDbRepository
    {
        private readonly IMongoDatabase _database;

        public MongoDbRepository(IMongoClient client, IOptions<MongoDbSettings> mongoDbSettings)
        {
            _database = client.GetDatabase(mongoDbSettings.Value.DbName);
        }

        private IMongoCollection<T> GetCollection<T>()
            where T : class
        {
            return _database.GetCollection<T>("rows");
        }
        public IMongoQueryable<T> GetQueryable<T>()
            where T : class
        {
            return GetCollection<T>().AsQueryable();
        }

        public async Task InsertAsync<T>(T entity)
            where T : class
        {
            await GetCollection<T>().InsertOneAsync(entity);
        }

        public UpdateResult Update<T>(FilterDefinition<T> filter, UpdateDefinition<T> entity)
            where T : class
        {
            return GetCollection<T>().UpdateOne(filter, entity);
        }
    }
}
