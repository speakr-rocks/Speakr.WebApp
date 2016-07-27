using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Controllers;

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
    }
}
