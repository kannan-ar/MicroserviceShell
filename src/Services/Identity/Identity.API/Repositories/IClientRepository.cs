﻿using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Identity.API.Repositories
{
    public interface IClientRepository
    {
        Task AddClient(Client client);
        Task<List<Client>> GetAllClients();
        Task<Client> GetClient(string clientId);
        Task EditClient(string id, Client client);
        Task Delete(string clientId);
        Task Clone(string clientId, string newClientId);
    }
}
