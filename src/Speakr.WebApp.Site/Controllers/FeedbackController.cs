using Microsoft.AspNetCore.Mvc;
using Speakr.WebApp.Site.Services.Feedback;
using Speakr.WebApp.Site.ViewModels.Feedback;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        private IFeedbackFormService _feedbackFormService;

        public FeedbackController(IFeedbackFormService feedbackFormService)
        {
            _feedbackFormService = feedbackFormService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index(string talkId)
        {
            // If api returns 404 for talk id:
            if (talkId.Equals("abcde"))
            {
                return RedirectToAction("TalkNotFound", "Home", new { TalkId = talkId });
            }

            // If api returns 200, it'll have a questionnaire form:
            var viewModel = await _feedbackFormService.GetReviewFormForTalkId(talkId); 
            
            return View("Index", viewModel);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index(FeedbackViewModel submittedReview)
        {
            if (ModelState.IsValid)
            {
                await _feedbackFormService.PostReviewForm(submittedReview);

                // If Api returns fail
                // Redirect to view and tell user to try later

                return View("_feedbackSavedSuccessfully");
            }

            return View("Index", submittedReview);
        }
    }
}
