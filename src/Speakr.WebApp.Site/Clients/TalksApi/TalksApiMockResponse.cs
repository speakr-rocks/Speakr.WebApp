using Speakr.WebApp.Site.Models.ReviewForm;
using Speakr.WebApp.Site.Models.Talks;
using System;
using System.Collections.Generic;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public static class TalksApiMockResponse
    {
        public static TalksModel GetTalkById(string talkId)
        {
            var questionnaire = new List<ReviewFormQuestions>
            {
                new ReviewFormQuestions
                {
                    QuestionId = "Question-1",
                    Question = "How much did you enjoy the talk?",
                    Answer = "",
                    ResponseType = ResponseTypes.Emoji
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-2",
                    Question = "How would you rate this talk?",
                    Answer = "",
                    ResponseType = ResponseTypes.Rating
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-3",
                    Question = "Did you learn anything useful?",
                    Answer = "",
                    ResponseType = ResponseTypes.YesNo
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-4",
                    Question = "Would you recommend this talk to a friend/colleague?",
                    Answer = "",
                    ResponseType = ResponseTypes.YesNo
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-5",
                    Question = "Do you have any suggestions to improve this talk?",
                    Answer = "",
                    ResponseType = ResponseTypes.Text
                },

                new ReviewFormQuestions
                {
                    QuestionId = "Question-6",
                    Question = "Any other comments?",
                    Answer = "",
                    ResponseType = ResponseTypes.Text
                }
            };

            return new TalksModel()
                {
                    TalkId = talkId,
                    TalkName = "My First Talk",
                    SpeakerId = "guid_speaker_id",
                    SpeakerName = "J-Wow",
                    Questionnaire = questionnaire
                };
        }

        public static ReviewFormResponse ReviewFormResponseModelMock(string talkId)
        {
            var model = GetTalkById(talkId);

            var response = new ReviewFormResponse()
            {
                Questionnaire = model.Questionnaire,
                ReviewerId = "",
                SubmissionTime = DateTime.Now
            };

            return response;
        }

    }
}
