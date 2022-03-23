using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;

namespace Identity.API.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ConfigurationDbContext context;

        public ClientRepository(ConfigurationDbContext context)
        {
            this.context = context;
        }

        public async Task AddClient(Client client)
        {
            context.Clients.Add(client.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}
