using NUnit.Framework;
using System.Collections.Generic;

namespace Speakr.WebApp.Site.Tests.Areas.Feedback
{
    public class WhenSubmittingFeedbackForm
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AndViewModelValidates_ThenResponseIsMappedCorrectly()
        {
            //var id = "12345";

            //var baseform = TalksApiMockResponse.GetTalkById(id);

            //var submittedReview = new SubmittedReviewForm();
            //submittedReview.TalkId = id;
            //submittedReview.Questionnaire = GenerateValidQuestionnaireResponse();

            //var expectedModel = TalksApiMockResponse.ReviewFormResponseModelMock(id);

            //var controller = new FeedbackController(new ReviewFormService(new TalksApi()));
            //var actionResult = (ViewResult)controller.Index(submittedReview).Result;

            //Assert.That(actionResult, Is.Not.Null);
            //Assert.That(actionResult.ViewName, Is.EqualTo("_reviewFormSavedSuccessfully"));
        }

        

        [Test]
        public void AndViewModelIsInvalid_ThenResponseIsMappedCorrectly()
        {
            //var id = "12345";

            //var baseform = TalksApiMockResponse.GetTalkById(id);

            //var model = new ReviewFormViewModel();
            //model.TalkDetails = baseform.TalkDetails;
            //model.Questionnaire = baseform.Questionnaire;

            //var expectedModel = TalksApiMockResponse.ReviewFormResponseModelMock(id);

            //var controller = new ReviewFormController(new ReviewFormService(new TalksApi()));
            //var actionResult = (ViewResult)controller.Index(model).Result;

            //Assert.That(actionResult, Is.Not.Null);
            //Assert.That(actionResult.ViewName, Is.EqualTo("_reviewFormSavedSuccessfully"));
        }

        private IList<Question> GenerateValidQuestionnaireResponse()
        {
            return new List<Question> {
                new Question
                {
                    QuestionId = "Question-1",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-2",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-3",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-4",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-5",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-6",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                }
                };
        }

        private IList<Question> GenerateExpectedMappedModel()
        {
            return new List<Question> {
                new Question
                {
                    QuestionId = "Question-1",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-2",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-3",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-4",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-5",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new Question
                {
                    QuestionId = "Question-6",
                    QuestionText = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                }
                };
        }
    }
}
