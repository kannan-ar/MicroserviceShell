using Identity.API.Repositories;
using IdentityServer4.Models;

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

        public async Task Delete(string clientId)
        {
            await repository.Delete(clientId);
        }

        public async Task<List<Client>> GetClients()
        {
            return await repository.GetAllClients();
        }
    }
}
