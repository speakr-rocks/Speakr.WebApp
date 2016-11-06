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

        public async Task PostTalk(Talk requestBody)
        {
            // POST ~/talks
        }

        public async Task<Talk> GetTalkById(int talkId)
        {
            return await GetAsync<Talk>($"talks?talkid={talkId}");
        }

        public async Task<FeedbackForm> GetFeedbackFormByEasyAccessKey(string easyAccessKey)
        {
            return await GetAsync<FeedbackForm>($"talks/{easyAccessKey}/FeedbackForm");
        }

        public async Task PostFeedbackForm(int easyAccessKey, FeedbackResponse response)
        {

            Debug.WriteLine($"Posting on client: {_httpClient.GetHashCode()}");
            // POST ~/talks/{easyAccessKey}/FeedbackForm
        }
    }
}
