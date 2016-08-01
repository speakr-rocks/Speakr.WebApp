using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Site.Clients.TalksApi;
using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using Speakr.WebApp.Site.Controllers;
using Speakr.WebApp.Site.Services.ReviewForm;
using Speakr.WebApp.Site.Tests.Helpers;
using Speakr.WebApp.Site.ViewModels.Feedback;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.Tests.Areas.Feedback
{
    public class WhenSubmittingFeedbackForm
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("Not using MVC postback for validation yet")]
        public void AndFeedbackIsPosted_ThenViewModelIsValidatedCorrectly()
        {
            var model = new FeedbackViewModel();
            var expectedMessage = "Please provide an answer to this question";

            var controller = new FeedbackController(new FeedbackFormService(new TalksApi()));

            var validationErrors = CheckForValidationErrors(controller, model);

            var actionResult = (ViewResult)controller.Index(model).Result;
            var modelState = controller.ModelState;

            Assert.That(validationErrors.Count, Is.EqualTo(1));
            Assert.That(validationErrors[0].ErrorMessage, Is.EqualTo(expectedMessage));

            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void AndFeedbackIsPosted_ThenShouldRedirectSuccessfully()
        {
            var model = CreateFeedbackViewModelMock();
            var controller = new FeedbackController(new FeedbackFormService(new TalksApi()));

            var actionResult = (ViewResult)controller.Index(model).Result;

            Assert.That(actionResult.ViewName, Is.EqualTo("_feedbackSavedSuccessfully"));
        }

        private static FeedbackViewModel CreateFeedbackViewModelMock()
        {
            var temp = TalksApiMockResponse.GetTalkById("12345");
            var model = new FeedbackViewModel()
            {
                TalkId = temp.TalkId,
                TalkName = temp.TalkName,
                SpeakerId = temp.SpeakerId,
                SpeakerName = temp.SpeakerName,
                Questionnaire = temp.Questionnaire
            };

            return model;
        }

        [Test]
        [Ignore("Need mocking framework")]
        public void AndFeedbackIsPosted_ThenResponseMappedCorrectly()
        {
            var model = new FeedbackViewModel();
            var expectedDTO = new FeedbackDTO();

            // Mock talksapi. Should have been called with expected DTO
            var controller = new FeedbackController(new FeedbackFormService(new TalksApi()));

            var validationErrors = CheckForValidationErrors(controller, model);

            var actionResult = (ViewResult)controller.Index(model).Result;
            var modelState = controller.ModelState;

            //Assert.That(TalksApi, WasCalledWithParam(expectedDTO));

            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
        }

        private static IList<ValidationResult> CheckForValidationErrors(FeedbackController controller, FeedbackViewModel model)
        {
            var validationErrors = ViewModelValidation.Validate(model);

            if (validationErrors.Count > 0)
            {
                controller.ViewData.ModelState.AddModelError(nameof(model.TalkId), validationErrors[0].ErrorMessage);
            }

            return validationErrors;
        }
    }
}
