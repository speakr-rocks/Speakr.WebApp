using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;
using Speakr.WebApp.Site.Clients.TalksApi;
using Speakr.WebApp.Site.Controllers;
using Speakr.WebApp.Site.Services.ReviewForm;
using Speakr.WebApp.Site.Tests.Helpers;
using Speakr.WebApp.Site.ViewModels.Feedback;
using Speakr.WebApp.Site.ViewModels.Home;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.Tests.Areas.Feedback
{
    public class WhenCallingIndex
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AndTalkIsFound_ThenIndexShouldNotReturnNull()
        {
            var controller = new FeedbackFormController(new FeedbackFormService(new TalksApi()));
            var actionResult = (ViewResult)controller.Index("12345").Result;
            var model = (FeedbackViewModel)actionResult.Model;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
            Assert.That(model, Is.TypeOf(typeof(FeedbackViewModel)));
        }

        [Test]
        public void AndTalkIsNotFound_ThenShouldRedirectWithError()
        {
            var controller = new FeedbackFormController(new FeedbackFormService(new TalksApi()));
            var actionResult = (RedirectToActionResult)controller.Index("abcde").Result;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ActionName, Is.EqualTo("TalkNotFound"));
            Assert.That(actionResult.ControllerName, Is.EqualTo("Home"));
        }

        [Test]
        public void AndTalkIsPosted_ThenShouldRedirectSuccessfully()
        {
            
        }

        [Test]
        public void ViewModelObjectsGetMappedCorrectly()
        {

        }


        private static IList<ValidationResult> CheckForValidationErrors(HomeController controller, GetReviewFormViewModel model)
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
