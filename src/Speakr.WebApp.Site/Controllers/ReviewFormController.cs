using Microsoft.AspNetCore.Mvc;
using Speakr.WebApp.Site.Models.ReviewForm;
using Speakr.WebApp.Site.Services.ReviewForm;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Controllers
{
    [Route("reviewform")]
    public class ReviewFormController : Controller
    {
        private IReviewFormService _reviewFormService;

        public ReviewFormController(IReviewFormService reviewFormService)
        {
            _reviewFormService = reviewFormService;
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
            var viewModel = await _reviewFormService.GetReviewFormForTalkId(talkId); 
            
            return View("Index", viewModel);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index(SubmittedReviewForm submittedReview)
        {
            if (ModelState.IsValid)
            {
                await _reviewFormService.PostReviewForm(submittedReview);

                // If Api returns fail
                // Redirect to view and tell user to try later

                return View("_reviewFormSavedSuccessfully");
            }

            await _reviewFormService.RegenerateReviewForm(submittedReview);

            return View("Index", submittedReview);
        }
    }
}
