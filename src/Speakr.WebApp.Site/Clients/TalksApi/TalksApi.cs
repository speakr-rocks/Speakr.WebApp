using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Diagnostics;
using System.Net.Http;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public class TalksApi : RestClient, ITalksApi
    {
        public TalksApi(string baseUrl) : base(baseUrl)
        {
            Debug.WriteLine("Created TalksApi Http Client");
        }

        public void PostTalk(Talk requestBody)
        {
            // POST ~/talks
        }

        public Talk GetTalkById(int talkId)
        {
            return Get<Talk>($"talks/{talkId}");
        }

        public FeedbackForm GetFeedbackFormByEasyAccessKey(string easyAccessKey)
        {
            return Get<FeedbackForm>($"feedbackform?key={easyAccessKey}");
        }

        public HttpResponseMessage PostReviewForTalk(int talkId, ReviewResponse response)
        {
            return Post($"talks/{talkId}/reviews", response);
        }
    }
}
