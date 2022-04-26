using Common.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ShellApp.Controllers
{
    public class ShellController : Controller
    {
        private readonly ILogger<ShellController> _logger;

        public ShellController(ILogger<ShellController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
