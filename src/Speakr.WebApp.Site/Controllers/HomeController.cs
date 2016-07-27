using Microsoft.AspNetCore.Mvc;

namespace Speakr.WebApp.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}