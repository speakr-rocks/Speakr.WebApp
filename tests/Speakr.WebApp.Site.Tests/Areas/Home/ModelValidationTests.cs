using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;
using Speakr.WebApp.Site.Tests.Helpers;
using Speakr.WebApp.Site.ViewModels.Home;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.Tests.Areas.Home
{
    public class ModelValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("", "The TalkId field is required.")]
        [TestCase("123", "The field TalkId must be a string or array type with a minimum length of '4'.")]
        public void InvalidTalkIdShowCorrectErrorMessage(string talkId, string expectedMessage)
        {
            var model = new CheckTalkIdViewModel() { TalkId = talkId };
            var controller = new HomeController();

            var validationErrors = CheckForValidationErrors(controller, model);

            var actionResult = (ViewResult)controller.CheckTalkIdCode(model);
            var modelState = controller.ModelState;

            Assert.That(validationErrors.Count, Is.EqualTo(1));
            Assert.That(validationErrors[0].ErrorMessage, Is.EqualTo(expectedMessage));

            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
        }

        private static IList<ValidationResult> CheckForValidationErrors(HomeController controller, CheckTalkIdViewModel model)
        {
            var validationErrors = ModelViewValidation.Validate(model);

            if (validationErrors.Count > 0)
            {
                controller.ViewData.ModelState.AddModelError(nameof(model.TalkId), validationErrors[0].ErrorMessage);
            }

            return validationErrors;
        }
    }
}
