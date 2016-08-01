using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;
using Speakr.WebApp.Site.ViewModels.Home;

namespace Speakr.WebApp.Site.Tests.Areas.Home
{
    public class WhenCallingHomeController
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Index_ShouldNotReturnNull()
        {
            var controller = new HomeController();
            var actionResult = (ViewResult)controller.Index();

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void TalkNotFound_ShouldReturnModelWithErrorMessage()
        {
            var controller = new HomeController();
            var actionResult = (ViewResult)controller.TalkNotFound("12345");
            var modelResult = (GetReviewFormViewModel)actionResult.Model;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
            Assert.That(modelResult.TalkId, Is.EqualTo("12345"));
            Assert.That(modelResult.TalkIdErrorMessage, Is.EqualTo("Talk not found"));
        }
    }
}
