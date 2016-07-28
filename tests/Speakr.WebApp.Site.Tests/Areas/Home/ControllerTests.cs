using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;
using Speakr.WebApp.Site.ViewModels.Home;

namespace Speakr.WebApp.Site.Tests
{
    public class HomeControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IndexViewLoadsCorrectly()
        {
            var controller = new HomeController();
            var actionResult = (ViewResult)controller.Index();

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void CheckTalkIdCodeRedirectsCorrectly()
        {
            var model = new CheckTalkIdViewModel() { TalkId = "12345" };

            var controller = new HomeController();
            var actionResult = (RedirectToActionResult)controller.CheckTalkIdCode(model);

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ControllerName, Is.EqualTo("ratings"));
            Assert.That(actionResult.ActionName, Is.EqualTo("form"));
            Assert.That(actionResult.RouteValues["TalkId"], Is.EqualTo("12345"));
        }
    }
}
