using Microsoft.AspNetCore.Mvc;


namespace Speakr.WebApp.Site.Controllers
{
    [Route("ratings")]
    public class RatingsController : Controller
    {
        [Route("DisplayForm")]
        public IActionResult DisplayForm(int talkId)
        {
            return Content("Display Form " + talkId);
        }
    }
}
