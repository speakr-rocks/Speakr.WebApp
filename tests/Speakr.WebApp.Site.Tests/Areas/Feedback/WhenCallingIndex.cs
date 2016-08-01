using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Speakr.WebApp.Site.Clients.TalksApi;
using Speakr.WebApp.Site.Controllers;
using Speakr.WebApp.Site.Services.ReviewForm;
using Speakr.WebApp.Site.ViewModels.Feedback;

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
            var controller = new FeedbackController(new FeedbackFormService(new TalksApi()));
            var actionResult = (ViewResult)controller.Index("12345").Result;
            var model = (FeedbackViewModel)actionResult.Model;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ViewName, Is.EqualTo("Index"));
            Assert.That(model, Is.TypeOf(typeof(FeedbackViewModel)));
        }

        [Test]
        public void AndTalkIsFound_ThenViewModelShouldBeMappedCorrectly()
        {
            var controller = new FeedbackController(new FeedbackFormService(new TalksApi()));
            var actionResult = (ViewResult)controller.Index("12345").Result;
            var model = (FeedbackViewModel)actionResult.Model;

            Assert.That(model.TalkId, Is.EqualTo("12345"));
            Assert.That(model.TalkName, Is.EqualTo("My First Talk"));
            Assert.That(model.SpeakerId, Is.EqualTo("guid_speaker_id"));
            Assert.That(model.SpeakerName, Is.EqualTo("J-Wow"));
            Assert.That(model.Questionnaire.Count, Is.EqualTo(6));
        }

        [Test]
        public void AndTalkIsNotFound_ThenShouldRedirectWithError()
        {
            var controller = new FeedbackController(new FeedbackFormService(new TalksApi()));
            var actionResult = (RedirectToActionResult)controller.Index("abcde").Result;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.ActionName, Is.EqualTo("TalkNotFound"));
            Assert.That(actionResult.ControllerName, Is.EqualTo("Home"));
        }
    }
}
