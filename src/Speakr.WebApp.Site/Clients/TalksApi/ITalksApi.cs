using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Net.Http;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public interface ITalksApi
    {
        void PostTalk(Talk requestBody);
        Talk GetTalkById(int talkId);
        FeedbackForm GetFeedbackFormByEasyAccessKey(string easyAccessKey);
        HttpResponseMessage PostReviewForTalk(int talkId, ReviewResponse response);
    }
}