using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public class TalksApi : ITalksApi
    {
        public async Task<TalksDTO> GetTalkById(string talkId)
        {
            return await Task.FromResult(TalksApiMockResponse.GetTalkById(talkId));
        }

        public async Task PostReviewResponse(string talkId, FeedbackDTO response)
        {
            // POST ~api/talks/{talkId}/responses
        }
    }
}
