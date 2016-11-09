using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public interface ITalksApi
    {
        FeedbackForm GetFeedbackFormByEasyAccessKey(string talkId);
        void PostFeedbackForm(int talkdId, FeedbackResponse response);
    }
}