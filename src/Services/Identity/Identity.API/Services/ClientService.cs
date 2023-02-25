using Identity.API.Repositories;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository repository;

        public ClientService(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddClient(Client client)
        {
            client.AllowAccessTokensViaBrowser = true;
            await repository.AddClient(client);
        }

        public async Task Clone(string clientId, string newClientId)
        {
            await repository.Clone(clientId, newClientId);
        }

        public async Task Delete(string clientId)
        {
            await repository.Delete(clientId);
        }

        public async Task EditClient(string id, Client client)
        {
            await repository.EditClient(id, client);
        }

        public async Task<Client> GetClient(string clientId)
        {
            return await repository.GetClient(clientId);
        }

        public async Task<List<Client>> GetClients()
        {
            return await repository.GetAllClients();
        }
    }
}
