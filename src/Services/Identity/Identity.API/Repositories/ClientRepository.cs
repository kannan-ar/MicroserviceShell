using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Entities = IdentityServer4.EntityFramework.Entities;

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

        public async Task Delete(string clientId)
        {
            var client = context.Clients.FirstOrDefault(x => x.ClientId == clientId);

            if(client != null)
            {
                context.Clients.Remove(client);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Client>> GetAllClients()
        {
            var clients = await context.Clients
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .ToListAsync();
            return clients.Select(x => x.ToModel()).ToList();
        }
    }
}
