using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;
using Speakr.WebApp.Site.Tests.Helpers;
using Speakr.WebApp.Site.ViewModels.Home;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.Tests.Areas.Home
{
    public class HomeControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IndexShouldNotReturnNull()
        {
            var controller = new HomeController();
            var actionResult = (ViewResult)controller.Index();

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void TalkNotFoundReturnsModelWithErrorMessage()
        {
            var controller = new HomeController();
            var actionResult = (ViewResult)controller.TalkNotFound("12345");
            var modelResult = (GetReviewFormViewModel)actionResult.Model;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
            Assert.That(modelResult.TalkId, Is.EqualTo("12345"));
            Assert.That(modelResult.TalkIdErrorMessage, Is.EqualTo("Talk not found"));
        }

        [TestCase("12345")]
        public void CheckTalkIdShouldRedirectForValidTalkIds(string talkId)
        {
            var model = new GetReviewFormViewModel() { TalkId = talkId};

            var controller = new HomeController();
            var actionResult = (RedirectToActionResult)controller.CheckTalkIdCode(model);

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ActionName, Is.EqualTo("Index"));
            Assert.That(actionResult.ControllerName, Is.EqualTo("reviewform"));
            Assert.That(actionResult.RouteValues["TalkId"], Is.EqualTo("12345"));
        }

        [TestCase("", "Please enter your talk's ID")]
        [TestCase("123", "Talk ID's have at least 4 characters")]
        public void CheckTalkIdShouldHandleInvalidValues(string talkId, string expectedMessage)
        {
            var model = new GetReviewFormViewModel() { TalkId = talkId };
            var controller = new HomeController();

            var validationErrors = CheckForValidationErrors(controller, model);

            var actionResult = (ViewResult)controller.CheckTalkIdCode(model);
            var modelState = controller.ModelState;

            Assert.That(validationErrors.Count, Is.EqualTo(1));
            Assert.That(validationErrors[0].ErrorMessage, Is.EqualTo(expectedMessage));

            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
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
