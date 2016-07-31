using System.Threading.Tasks;
using Speakr.WebApp.Site.Models.ReviewForm;
using Speakr.WebApp.Site.Models.Talks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public interface ITalksApi
    {
        Task<TalksModel> GetTalkById(string talkId);
        Task PostReviewResponse(string talkdId, ReviewFormResponse response);
    }
}