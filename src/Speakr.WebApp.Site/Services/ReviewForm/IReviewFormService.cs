using System.Threading.Tasks;
using Speakr.WebApp.Site.ViewModels.ReviewForm;
using Speakr.WebApp.Site.Models.ReviewForm;

namespace Speakr.WebApp.Site.Services.ReviewForm
{
    public interface IReviewFormService
    {
        Task<ReviewFormViewModel> GetReviewFormForTalkId(string talkId);
        Task PostReviewForm(SubmittedReviewForm model);
        Task<ReviewFormViewModel> RegenerateReviewForm(SubmittedReviewForm model);
    }
}