using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;
using Speakr.WebApp.Site.Controllers;
using Speakr.WebApp.Site.Tests.Helpers;
using Speakr.WebApp.Site.ViewModels.Home;
using Speakr.WebApp.Site.ViewModels.ReviewForm;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.Tests.Areas.ReviewForm
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
            var controller = new ReviewFormController();
            var actionResult = (ViewResult)controller.Index("12345");
            var model = (ReviewFormViewModel)actionResult.Model;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
            Assert.That(model, Is.TypeOf(typeof(ReviewFormViewModel)));
        }

        [Test]
        public void AndTalkIsNotFound_ThenShouldRedirectWithError()
        {
            var controller = new ReviewFormController();
            var actionResult = (RedirectToActionResult)controller.Index("abcde");

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ActionName, Is.EqualTo("TalkNotFound"));
            Assert.That(actionResult.ControllerName, Is.EqualTo("Home"));
        }

        [Test]
        public void AndTalkIsPosted_ThenShouldRedirectSuccessfully()
        {
            var model = new ReviewFormViewModel()
            {
                SpeakerName = "Joao",
                TalkId = "12345",
                TalkName = "TestTalk"
            };

            var controller = new ReviewFormController();
            var actionResult = (ViewResult)controller.Index(model);

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("_reviewFormSavedSuccessfully"));
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
