using IdentityServer4.Models;

namespace Identity.API.Services
{
    public interface IClientService
    {
        Task AddClient(Client client);
        Task<List<Client>> GetClients();
        Task Delete(string clientId);
    }
}
