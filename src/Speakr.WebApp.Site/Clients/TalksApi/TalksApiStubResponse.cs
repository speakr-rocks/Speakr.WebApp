using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Collections.Generic;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public static class TalksApiStubResponse
    {
        public static TalksDTO GetTalkById(string talkId)
        {
            var questionList = new List<Question>
            {
                new Question
                {
                    QuestionId = "Question-1",
                    QuestionText = "How much did you enjoy the talk?",
                    Answer = "",
                    ResponseType = ResponseTypes.Emoji,
                    IsRequired = true
                },

                new Question
                {
                    QuestionId = "Question-2",
                    QuestionText = "How would you rate this talk?",
                    Answer = "",
                    ResponseType = ResponseTypes.Rating,
                    IsRequired = false
                },

                new Question
                {
                    QuestionId = "Question-3",
                    QuestionText = "Did you learn anything useful?",
                    Answer = "",
                    ResponseType = ResponseTypes.YesNo,
                    IsRequired = true
                },

                new Question
                {
                    QuestionId = "Question-4",
                    QuestionText = "Would you recommend this talk to a friend/colleague?",
                    Answer = "",
                    ResponseType = ResponseTypes.YesNo,
                    IsRequired = false
                },

                new Question
                {
                    QuestionId = "Question-5",
                    QuestionText = "Do you have any suggestions to improve this talk?",
                    Answer = "",
                    ResponseType = ResponseTypes.Text,
                    IsRequired = true
                },

                new Question
                {
                    QuestionId = "Question-6",
                    QuestionText = "Any other comments?",
                    Answer = "",
                    ResponseType = ResponseTypes.Text,
                    IsRequired = false
                }
            };

            return new TalksDTO()
                {
                    TalkId = talkId,
                    TalkName = "My First Talk",
                    SpeakerId = "guid_speaker_id",
                    SpeakerName = "J-Wow",
                    Questionnaire = questionList
                };
        }

        //public static FeedbackResponse ReviewFormResponseModelMock(string talkId)
        //{
            //var model = GetTalkById(talkId);

            //var response = new FeedbackResponse()
            //{
            //    Questionnaire = model.Questionnaire,
            //    ReviewerId = "",
            //    SubmissionTime = DateTime.Now
            //};

            //return response;
        //}
    }
}
