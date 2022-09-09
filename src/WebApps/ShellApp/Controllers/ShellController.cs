using Common.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShellApp.API;
using ShellApp.Core.Services;
using ShellApp.Route;
using System.Threading.Tasks;

namespace ShellApp.Controllers
{
    public class ShellController : Controller
    {
        private readonly ILogger<ShellController> _logger;
        private readonly IPageService _pageService;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public ShellController(
            ILogger<ShellController> logger,
            IHttpContextAccessor httpContextAccesor,
            IPageService pageService)
        {
            _logger = logger;
            _httpContextAccesor = httpContextAccesor;
            _pageService = pageService;
        }

        private bool IsAuthenticated => _httpContextAccesor.HttpContext.User.Identity.IsAuthenticated;
       
        public async Task<ActionResult> Index()
        {
            var pageName = (string)HttpContext.Items[RouteConstants.Page];

            if(IsAuthenticated && !string.IsNullOrWhiteSpace(pageName))
            {
                var pageData = await _pageService.Get(pageName);
                return View(pageData);
            }

            return View();
        }

        [Authorize]
        [Route("Links")]
        public IActionResult Links()
        {
            return View();
        }

        [Authorize]
        [HttpPost("Links")]
        [ValidateAntiForgeryToken]
        public IActionResult Links(string links)
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Callback()
        {
            return View();
        }

        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exception != null)
            {
                _logger.LogAppError(LogCategory.ShellApp, "{Error}{StackTrace}", exception.Error.Message, exception.Error.StackTrace);
            }

            return View();
        }
    }
}
