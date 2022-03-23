using AutoMapper;
using Identity.API.Models.ClientViewModels;
using Identity.API.Services;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var item = mapper.Map<Client>(model);

            await service.AddClient(item);

            return Content("Client created successfully");
        }
    }
}
