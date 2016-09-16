using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public class TalksApi : ITalksApi
    {
        public async Task<FeedbackForm> GetTalkById(string talkId)
        {
            return await Task.FromResult(TalksApiStubResponse.GetTalkById(talkId));
        }

        public async Task PostReviewResponse(string talkId, FeedbackResponse response)
        {
            // POST ~api/talks/{talkId}/responses
        }
    }
}
