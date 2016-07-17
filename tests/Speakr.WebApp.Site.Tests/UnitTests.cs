using NUnit.Framework;
using Speakr.WebApp.Controllers;

namespace Speakr.WebApp.Site.Tests
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HomeControllerIndexShouldNotBeNull()
        {
            var controller = new HomeController();
            Assert.That(controller.Index(), Is.Not.Null);
        }

    }
}
