using Microsoft.AspNetCore.Mvc;

namespace Speakr.WebApp.Site.Controllers.ViewComponents
{
    [Route("ratings")]
    public class RatingsController : Controller
    {
        [HttpGet]
        [Route("form")]
        public IActionResult RatingForm(string id)
        {
            return View("Index");
        }
    }
}
