using Speakr.WebApp.Site.Clients.TalksApi;
using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using Speakr.WebApp.Site.Services.Feedback;
using Speakr.WebApp.Site.ViewModels.Feedback;
using System;
using System.Linq;
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
            var viewModel = MapToViewModel(talk);

            return viewModel;
        }

        public async Task PostReviewForm(FeedbackViewModel submittedForm)
        {
            var response = MapFeedbackViewModelToRevieForm(submittedForm);

            await _talksApiClient.PostReviewResponse(submittedForm.TalkId, response);
        }

        private static FeedbackViewModel MapToViewModel(TalksDTO talk)
        {
            var viewModel = new FeedbackViewModel();
            viewModel.TalkId = talk.TalkId;
            viewModel.TalkName = talk.TalkName;
            viewModel.SpeakerId = talk.SpeakerId;
            viewModel.SpeakerName = talk.SpeakerName;

            viewModel.Questionnaire = talk.Questionnaire.Select(x => new QuestionViewModel
            {
                QuestionId = x.QuestionId,
                IsRequired = x.IsRequired,
                QuestionText = x.QuestionText,
                ResponseType = x.ResponseType,
                Answer = x.Answer
            }).ToList();

            return viewModel;
        }

        private static FeedbackDTO MapFeedbackViewModelToRevieForm(FeedbackViewModel submittedForm)
        {
            return new FeedbackDTO
            {
                TalkId = submittedForm.TalkId,
                ReviewerId = "",
                Questionnaire = submittedForm.Questionnaire.Select(x => new Question
                {
                    QuestionId = x.QuestionId,
                    IsRequired = x.IsRequired,
                    QuestionText = x.QuestionText,
                    ResponseType = x.ResponseType,
                    Answer = x.Answer
                }).ToList(),
                SubmissionTime = DateTime.Now
            };
        }
    }
}
