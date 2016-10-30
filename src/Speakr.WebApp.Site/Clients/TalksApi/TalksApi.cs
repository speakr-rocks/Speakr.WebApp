using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public class TalksApi : ITalksApi
    {
        private readonly string _baseUrl = "talksapi.speakr.rocks";

        public async Task PostTalk(Talk requestBody)
        {
            // POST ~/talks
        }

        public async Task GetTalkById(int talkId)
        {
            // POST ~/talks?talkId={talkId}
        }

        public async Task<FeedbackForm> GetFeedbackFormByEasyAccessKey(string easyAccessKey)
        {
            // GET ~/talks/{easyAccessKey}/FeedbackForm
            return await Task.FromResult(TalksApiStubResponse.GetTalkById(easyAccessKey));
        }

        public async Task PostFeedbackForm(string easyAccessKey, FeedbackResponse response)
        {
            // POST ~/talks/{easyAccessKey}/FeedbackForm
        }
    }
}
