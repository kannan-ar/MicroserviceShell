using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Identity.API.Services
{
    public interface IClientService
    {
        Task AddClient(Client client);
        Task<List<Client>> GetClients();
        Task Delete(string clientId);
    }
}
