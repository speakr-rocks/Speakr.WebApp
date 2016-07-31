using Speakr.WebApp.Site.Models.ReviewForm;
using System.Collections.Generic;

namespace Speakr.WebApp.Site.Models.Talks
{
    public class TalksModel
    {
        public string TalkId { get; set; }
        public string TalkName { get; set; }
        public string SpeakerId { get; set; }
        public string SpeakerName { get; set; }
        public IList<ReviewFormQuestions> Questionnaire { get; set; }
    }

    public enum ResponseTypes
    {
        Text,
        Emoji,
        Rating,
        YesNo
    };
}
