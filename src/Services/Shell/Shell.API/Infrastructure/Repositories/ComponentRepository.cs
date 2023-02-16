using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shell.API.Domain.Repositories;
using Shell.API.Infrastructure.Entities;
using Shell.API.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModalEntities = Shell.API.Models.Entities;

namespace Shell.API.Infrastructure.Repositories
{
    public class ComponentRepository : MongoDbRepository<ModalEntities.Component, Component>, IComponentRepository
    {
        public ComponentRepository(IMongoClient client, IMapper mapper, IOptions<MongoDbSettings> mongoDbSettings)
            : base(mapper, client, mongoDbSettings)
        {
        }

        protected override string CollectionName => "components";

        public async Task<ModalEntities.Component> GetComponentAsync(string componentName)
        {
            return await GetFirstOrDefaultAsync(Builders<Component>.Filter.Eq(x => x.Name, componentName));
        }

        public async Task<IEnumerable<ModalEntities.Component>> GetComponentsAsync(bool requireAuthentication)
        {
            return await GetAsync(Builders<Component>.Filter.Eq(x => x.RequireAuthentication, requireAuthentication));
        }

        public async Task<ModalEntities.Component> UpdateComponentAsync(string componentName, ModalEntities.Component component)
        {
            return await UpdateAsync(
               Builders<Component>.Filter.Eq(x => x.ComponentName, componentName),
            Builders<Component>.Update
            .Set(p => p.Name, component.Name)
            .Set(p => p.Description, component.Description)
            .Set(p => p.RemoteName, component.RemoteName)
            .Set(p => p.RemoteEndpoint, component.RemoteEndpoint)
            .Set(p => p.ComponentName, component.ComponentName)
            .Set(p => p.RequireAuthentication, component.RequireAuthentication));
        }

        public async Task DeleteComponentAsync(string componentName)
        {
            await DeleteAsync(Builders<Component>.Filter.Eq(x => x.Name, componentName));
        }

        public async Task<bool> IsComponentExistsAsync(string componentName)
        {
            return await IsExistsAsync(Builders<Component>.Filter.Eq(x => x.Name, componentName));
        }
    }
}
