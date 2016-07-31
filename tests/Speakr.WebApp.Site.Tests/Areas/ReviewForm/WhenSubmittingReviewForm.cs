using NUnit.Framework;
using Speakr.WebApp.Site.Clients.TalksApi;
using Speakr.WebApp.Site.ViewModels.ReviewForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Speakr.WebApp.Site.Models.ReviewForm;
using Speakr.WebApp.Site.Controllers;
using Speakr.WebApp.Site.Services.ReviewForm;
using Speakr.WebApp.Site.Models.Talks;
using Microsoft.AspNetCore.Mvc;

namespace Speakr.WebApp.Site.Tests.Areas.ReviewForm
{
    public class WhenSubmittingReviewForm
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AndViewModelValidates_ThenResponseIsMappedCorrectly()
        {
            var id = "12345";

            var baseform = TalksApiMockResponse.GetTalkById(id);

            var submittedReview = new SubmittedReviewForm();
            submittedReview.TalkId = id;
            submittedReview.Questionnaire = GenerateValidQuestionnaireResponse();

            var expectedModel = TalksApiMockResponse.ReviewFormResponseModelMock(id);

            var controller = new ReviewFormController(new ReviewFormService(new TalksApi()));
            var actionResult = (ViewResult)controller.Index(submittedReview).Result;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("_reviewFormSavedSuccessfully"));
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

        private IList<ReviewFormQuestions> GenerateValidQuestionnaireResponse()
        {
            return new List<ReviewFormQuestions> {
                new ReviewFormQuestions
                {
                    QuestionId = "Question-1",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-2",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-3",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-4",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-5",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-6",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                }
                };
        }

        private IList<ReviewFormQuestions> GenerateExpectedMappedModel()
        {
            return new List<ReviewFormQuestions> {
                new ReviewFormQuestions
                {
                    QuestionId = "Question-1",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-2",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-3",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-4",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-5",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-6",
                    Question = "",
                    Answer = "answer1",
                    ResponseType = ResponseTypes.Text
                }
                };
        }
    }
}
