using Microsoft.AspNetCore.Mvc;
using Speakr.WebApp.Site.ViewModels.Home;

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

        [Route("TalkNotFound")]
        public IActionResult TalkNotFound(string TalkId)
        {
            var model = new GetReviewFormViewModel()
            {
                TalkId = TalkId,
                TalkIdErrorMessage = "Talk not found"
            };

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult CheckTalkIdCode(GetReviewFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "feedback", new { TalkId = model.TalkId });
            }

            return View("Index", model);
        }
    }
}