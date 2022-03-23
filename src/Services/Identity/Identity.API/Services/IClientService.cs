using IdentityServer4.Models;

namespace Identity.API.Services
{
    public interface IClientService
    {
        Task AddClient(Client client);
    }
}
