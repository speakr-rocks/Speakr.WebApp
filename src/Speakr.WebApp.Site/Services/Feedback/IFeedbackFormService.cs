using Speakr.WebApp.Site.ViewModels.Feedback;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Services.Feedback
{
    public interface IFeedbackFormService
    {
        Task<FeedbackViewModel> GetReviewFormForTalkId(string talkId);
        Task PostReviewForm(FeedbackViewModel model);
    }
}