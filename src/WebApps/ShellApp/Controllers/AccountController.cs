using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ShellApp.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public async Task<IActionResult> SignIn(string returnUrl)
        {
            //var user = User as ClaimsPrincipal;
            //var token = await HttpContext.GetTokenAsync("access_token");

            //if (token != null)
            //{
            //    ViewData["access_token"] = token;
            //}

            return RedirectToAction(nameof(ShellController.Index), "Shell");
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            var homeUrl = Url.Action(nameof(ShellController.Index), "Shell");
            return new SignOutResult(OpenIdConnectDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = homeUrl });
        }
    }
}
