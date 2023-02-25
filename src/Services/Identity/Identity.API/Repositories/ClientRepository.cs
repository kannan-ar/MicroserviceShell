using Identity.API.Extensions;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task Clone(string clientId, string newClientId)
        {
            var client = await GetClient(clientId);

            var newClient = client.DeepClone();

            newClient.ClientId = newClientId;
            newClient.ClientName = newClientId;

            await AddClient(newClient);
        }

        public async Task Delete(string clientId)
        {
            var client = context.Clients.FirstOrDefault(x => x.ClientId == clientId);

            if (client != null)
            {
                context.Clients.Remove(client);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditClient(string id, Client client)
        {
            var updatedClient = client.ToEntity();

            var existingClient = context.Clients
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.AllowedCorsOrigins)
                .FirstOrDefault(x => x.ClientId == id);

            existingClient.ClientId = updatedClient.ClientId;
            existingClient.ClientName = updatedClient.ClientName;
            existingClient.RedirectUris = updatedClient.RedirectUris;
            existingClient.PostLogoutRedirectUris = updatedClient.PostLogoutRedirectUris;
            existingClient.AllowedScopes = updatedClient.AllowedScopes;
            existingClient.AllowedCorsOrigins = updatedClient.AllowedCorsOrigins;

            await context.SaveChangesAsync();
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

        public async Task<Client> GetClient(string clientId)
        {
            var client = await context.Clients
                .Where(x => x.ClientId == clientId)
               .Include(x => x.RedirectUris)
               .Include(x => x.PostLogoutRedirectUris)
               .Include(x => x.AllowedScopes)
               .Include(x => x.AllowedGrantTypes)
               .Include(x => x.AllowedCorsOrigins)
               .Include(x => x.ClientSecrets)
               .Include(x => x.Claims)
               .FirstOrDefaultAsync();

            return client.ToModel();
        }
    }
}
