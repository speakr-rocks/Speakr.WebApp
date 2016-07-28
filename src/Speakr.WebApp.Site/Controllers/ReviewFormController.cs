using Microsoft.AspNetCore.Mvc;
using Speakr.WebApp.Site.ViewModels.ReviewForm;

namespace Speakr.WebApp.Site.Controllers
{
    [Route("reviewform")]
    public class ReviewFormController : Controller
    {
        [Route("")]
        public IActionResult Index(string TalkId)
        {
            // If api returns 404 for talk id:
            if (TalkId.Equals("abcde"))
            {
                return RedirectToAction("TalkNotFound", "Home", new { TalkId = TalkId });
            }

            // If api returns 200, it'll have a questionnaire form:
            var model = new ReviewFormViewModel();

            return View("Index", model);
        }
    }
}
