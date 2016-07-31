using Speakr.WebApp.Site.Models.ReviewForm;
using Speakr.WebApp.Site.Models.Talks;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public class TalksApi : ITalksApi
    {
        public async Task<TalksModel> GetTalkById(string talkId)
        {
            return await Task.FromResult(TalksApiMockResponse.GetTalkById(talkId));
        }

        public async Task PostReviewResponse(string talkId, ReviewFormResponse response)
        {
            // POST ~api/talks/{talkId}/responses
        }
    }
}
