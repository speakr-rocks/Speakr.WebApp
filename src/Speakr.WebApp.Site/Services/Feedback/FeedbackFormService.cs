using Speakr.WebApp.Site.Clients.TalksApi;
using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using Speakr.WebApp.Site.Services.Feedback;
using Speakr.WebApp.Site.ViewModels.Feedback;
using System;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Services.ReviewForm
{
    public class FeedbackFormService : IFeedbackFormService
    {
        private ITalksApi _talksApiClient;

        public FeedbackFormService(ITalksApi talksApiClient)
        {
            _talksApiClient = talksApiClient;
        }

        public async Task<FeedbackViewModel> GetReviewFormForTalkId(string talkId)
        {
            var talk = await _talksApiClient.GetTalkById(talkId);

            var viewModel = new FeedbackViewModel();
            viewModel.TalkId = talk.TalkId;
            viewModel.TalkName = talk.TalkName;
            viewModel.SpeakerId = talk.SpeakerId;
            viewModel.SpeakerName = talk.SpeakerName;

            viewModel.Questionnaire = talk.Questionnaire;

            return viewModel;
        }

        public async Task PostReviewForm(FeedbackViewModel submittedForm)
        {
            var response = new FeedbackDTO
            {
                TalkId = submittedForm.TalkId,
                ReviewerId = "",
                Questionnaire = submittedForm.Questionnaire,
                SubmissionTime = DateTime.Now
            };

            await _talksApiClient.PostReviewResponse(submittedForm.TalkId, response);
        }
    }
}
