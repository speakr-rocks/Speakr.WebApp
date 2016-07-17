using Microsoft.AspNetCore.Mvc;

namespace Speakr.WebApp.Controllers
{
    [Route("/"), Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}