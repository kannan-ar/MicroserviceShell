using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShellApp.Controllers
{
    public class ShellController : Controller
    {
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
    }
}
