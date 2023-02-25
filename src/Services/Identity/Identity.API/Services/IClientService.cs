using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Identity.API.Services
{
    public interface IClientService
    {
        Task AddClient(Client client);
        Task EditClient(string id, Client client);
        Task<List<Client>> GetClients();
        Task<Client> GetClient(string clientId);
        Task Delete(string clientId);
    }
}
