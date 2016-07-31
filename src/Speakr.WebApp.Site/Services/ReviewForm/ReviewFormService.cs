using Speakr.WebApp.Site.Clients.TalksApi;
using Speakr.WebApp.Site.Models.ReviewForm;
using Speakr.WebApp.Site.ViewModels.ReviewForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Speakr.WebApp.Site.Models.Talks;

namespace Speakr.WebApp.Site.Services.ReviewForm
{
    public class ReviewFormService : IReviewFormService
    {
        private ITalksApi _talksApiClient;

        public ReviewFormService(ITalksApi talksApiClient)
        {
            _talksApiClient = talksApiClient;
        }

        public async Task<ReviewFormViewModel> GetReviewFormForTalkId(string talkId)
        {
            var talk = await _talksApiClient.GetTalkById(talkId);

            var viewModel = new ReviewFormViewModel();
            viewModel.TalkId = talk.TalkId;
            viewModel.TalkName = talk.TalkName;
            viewModel.SpeakerId = talk.SpeakerId;
            viewModel.SpeakerName = talk.SpeakerName;

            viewModel.Questionnaire = talk.Questionnaire;

            return viewModel;
        }

        public async Task PostReviewForm(SubmittedReviewForm submittedForm)
        {
            var reviewForm = await _talksApiClient.GetTalkById(submittedForm.TalkId);

            var response = new ReviewFormResponse()
            {
                ReviewerId = "",
                Questionnaire = MapQuestionnaireToResponseModel(reviewForm, submittedForm),
                SubmissionTime = DateTime.Now
            };

            await _talksApiClient.PostReviewResponse(submittedForm.TalkId, response);
        }

        public async Task<ReviewFormViewModel> RegenerateReviewForm(SubmittedReviewForm submittedForm)
        {
            var reviewForm = await _talksApiClient.GetTalkById(submittedForm.TalkId);

            var viewModel = new ReviewFormViewModel();
            viewModel.TalkId = reviewForm.TalkId;
            viewModel.TalkName = reviewForm.TalkName;
            viewModel.SpeakerId = reviewForm.SpeakerId;
            viewModel.SpeakerName = reviewForm.SpeakerName;

            viewModel.Questionnaire = MapQuestionnaireToResponseModel(reviewForm, submittedForm);

            return viewModel;
        }

        private IList<ReviewFormQuestions> MapQuestionnaireToResponseModel(TalksModel apiModel, SubmittedReviewForm submittedFormModel)
        {
            foreach (var questions in apiModel.Questionnaire)
            {
                questions.Answer = submittedFormModel.Questionnaire.Where(x => x.QuestionId == questions.QuestionId).First().Answer;
                questions.ResponseType = submittedFormModel.Questionnaire.Where(x => x.QuestionId == questions.QuestionId).First().ResponseType;
            }

            return apiModel.Questionnaire;
        }
    }
}
