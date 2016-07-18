using Microsoft.AspNetCore.Mvc;

namespace Speakr.WebApp.Controllers
{
    [Route("/"), Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index(string Error = null)
        {
            if (Error == "InvalidTalkId")
            {
                ModelState.AddModelError("InvalidTalkId", "Please enter a valid talk Id");
            }
            return View();
        }

        [HttpGet]
        [Route("GetRatingForm")]
        public IActionResult GetRatingForm(string talkId)
        {
            // If talkid returns 404 from client:
            if (!talkId.Equals("1234"))
            {
                return RedirectToAction("Index", new { Error = "InvalidTalkId" });
            }

            return RedirectToAction("DisplayForm", "Ratings", new { talkId = talkId });
        }
    }
}