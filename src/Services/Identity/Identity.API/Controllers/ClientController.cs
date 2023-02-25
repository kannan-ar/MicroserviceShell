using AutoMapper;
using Identity.API.Extensions;
using Identity.API.Models.ClientViewModels;
using Identity.API.Services;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;
        private readonly IMapper mapper;

        public ClientController(IMapper mapper, IClientService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<ActionResult<List<ClientViewModel>>> Index()
        {
            var clients = await service.GetClients();
            return View(mapper.Map<List<ClientViewModel>>(clients));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<ClientEditModel>> Edit(string id)
        {
            var client = await service.GetClient(id);
            return View(mapper.Map<ClientEditModel>(client));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult<Client>> Details(string id)
        {
            var client = await service.GetClient(id);
            return View(mapper.Map<ClientDetailModel>(client));
        }

        public async Task<IActionResult> Clone(string id)
        {
            var client = await service.GetClient(id);
            var clonedClient = client.Clone();
            
            var clientId = Guid.NewGuid().ToString();

            clonedClient.ClientId = clientId;
            clonedClient.ClientName = clientId;

            await service.AddClient(clonedClient);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var item = mapper.Map<Client>(model);

            if (item.RequireClientSecret)
            {
                item.ClientSecrets = new List<Secret>
                {
                    new Secret(model.ClientSecret.Sha256())
                };
            }

            item.AllowedGrantTypes = GrantTypes.Code;
            item.RequirePkce = true;
            item.AllowAccessTokensViaBrowser = true;
            item.RequireConsent = false;

            await service.AddClient(item);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ClientEditModel model)
        {
            var item = mapper.Map<Client>(model);

            await service.EditClient(id, item);

            return RedirectToAction(nameof(Index));
        }
    }
}
