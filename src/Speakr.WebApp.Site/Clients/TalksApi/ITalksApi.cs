using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public interface ITalksApi
    {
        Task<FeedbackForm> GetFeedbackFormByEasyAccessKey(string talkId);
        Task PostFeedbackForm(string talkdId, FeedbackResponse response);
    }
}