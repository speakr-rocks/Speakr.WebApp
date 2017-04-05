﻿using Microsoft.AspNetCore.Mvc;
using Speakr.WebApp.Site.ViewModels.Feedback;
using System;
using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using Speakr.WebApp.Site.Clients.TalksApi;
using System.Linq;
using System.Net.Http;

namespace Speakr.WebApp.Site.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        private ITalksApi _talksApi;

        public FeedbackController(ITalksApi talksApi)
        {
            _talksApi = talksApi;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index(string easyAccessKey)
        {
            var feedbackForm = GetFeedbackForm(easyAccessKey);

            if (feedbackForm == null)
                return RedirectToAction("TalkNotFound", "Home", new { EasyAccessKey = easyAccessKey });

            return View("Index", feedbackForm);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Index(FeedbackFormViewModel review)
        {
            var reviewSubmissionResponse = PostReview(review);

            if (reviewSubmissionResponse.StatusCode != System.Net.HttpStatusCode.Created)
            {
                review.ErrorMessage = reviewSubmissionResponse.ReasonPhrase;
                return RedirectToAction("Index", "Feedback", review);
            }
            return View("_reviewSavedSuccessfully");
            // Can't just redirect, need to forward an error somehow!!
        }

        private FeedbackFormViewModel GetFeedbackForm(string easyAccessKey)
        {
            var form = _talksApi.GetFeedbackFormByEasyAccessKey(easyAccessKey);

            if (form == null)
                return null;

            return MapToViewModel(form);
        }

        private FeedbackFormViewModel MapToViewModel(FeedbackForm form)
        {
            if (form.Questionnaire == null || !form.Questionnaire.Any()) return null;

            var viewModel = new FeedbackFormViewModel();
            viewModel.TalkId = form.TalkId;
            viewModel.TalkName = form.TalkName;
            viewModel.SpeakerName = form.SpeakerName;

            viewModel.Questionnaire = form.Questionnaire.Select(x => new QuestionViewModel
            {
                QuestionId = x.QuestionId,
                IsRequired = x.IsRequired,
                QuestionText = x.QuestionText,
                AnswerType = x.AnswerType,
                Answer = x.Answer
            }).ToList();

            return viewModel;
        }

        private HttpResponseMessage PostReview(FeedbackFormViewModel feedbackFormAnswers)
        {
            var talkId = feedbackFormAnswers.TalkId;

            var feedbackResponse = new ReviewResponse
            {
                TalkId = feedbackFormAnswers.TalkId,
                ReviewerId = "",
                Questionnaire = feedbackFormAnswers.Questionnaire.Select(x => new Question
                {
                    QuestionId = x.QuestionId,
                    IsRequired = x.IsRequired,
                    QuestionText = x.QuestionText,
                    AnswerType = x.AnswerType,
                    Answer = x.Answer
                }).ToList(),
                SubmissionTime = DateTime.Now
            };

            var feedbackSubmissionResponse = _talksApi.PostReviewForTalk(talkId, feedbackResponse);
            return feedbackSubmissionResponse;
        }
    }
}
