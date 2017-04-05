using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Speakr.WebApp.Site.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace Speakr.WebApp.Site.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private IHostingEnvironment _env;

        public AccountController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Route("login")]
        public IActionResult Login(string returnUrl = "/")
        {
            return new ChallengeResult("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        [Route("logout")]
        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Auth0", new AuthenticationProperties
            {
                RedirectUri = Url.Action("", "Home")
            });
            await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        [Route("profile")]
        public IActionResult Profile()
        {
            return View(new UserProfileViewModel()
            {
                Name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                Country = User.Claims.FirstOrDefault(c => c.Type == "country")?.Value
            });
        }

        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        [Route("claims")]
        public IActionResult Claims()
        {
            if (_env.IsDevelopment())
            {
                return View();
            }

            return RedirectToAction("accessdenied");
        }
    }
}
