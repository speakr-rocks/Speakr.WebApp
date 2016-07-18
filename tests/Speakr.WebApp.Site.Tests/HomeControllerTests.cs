using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;
using System.Linq;

namespace Speakr.WebApp.Site.Tests
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
            Assert.That(controller.Index(), Is.Not.Null);
        }

        [Test]
        public void GetRatingFormForValidTalkRedirectsCorrectly()
        {
            var controller = new HomeController();
            var actionResult = (RedirectToActionResult)controller.GetRatingForm("1234");

            Assert.That(actionResult.ActionName, Is.EqualTo("DisplayForm"));
            Assert.That(actionResult.ControllerName, Is.EqualTo("Ratings"));
        }

        [Test]
        public void GetRatingFormForInvalidTalkRedirectsWithError()
        {
            var controller = new HomeController();
            var actionResult = (RedirectToActionResult)controller.GetRatingForm("1111");
            var expectedErrorMessage = "InvalidTalkId";

            Assert.That(actionResult.ActionName, Is.EqualTo("Index"));
            Assert.That(actionResult.ControllerName, Is.Null);
            Assert.That(actionResult.RouteValues.Count, Is.EqualTo(1));
            Assert.That(actionResult.RouteValues.Values.First, Is.EqualTo(expectedErrorMessage));
        }
    }
}
