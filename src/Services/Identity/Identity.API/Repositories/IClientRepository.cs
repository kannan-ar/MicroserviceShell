
using IdentityServer4.Models;

namespace Identity.API.Repositories
{
    public interface IClientRepository
    {
        Task AddClient(Client client);
        Task<List<Client>> GetAllClients();
        Task Delete(string clientId);
    }
}
