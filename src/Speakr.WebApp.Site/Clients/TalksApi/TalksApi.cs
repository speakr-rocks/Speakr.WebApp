using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

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
            return Get<Talk>($"talks?talkid={talkId}");
        }

        public FeedbackForm GetFeedbackFormByEasyAccessKey(string easyAccessKey)
        {
            return Get<FeedbackForm>($"talks/{easyAccessKey}/FeedbackForm");
        }

        public void PostFeedbackForm(int easyAccessKey, FeedbackResponse response)
        {

            Debug.WriteLine($"Posting on client: {_httpClient.GetHashCode()}");
            // POST ~/talks/{easyAccessKey}/FeedbackForm
        }
    }
}
