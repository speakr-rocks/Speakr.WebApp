using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Collections.Generic;

namespace Speakr.WebApp.Site.ViewModels.Feedback
{
    public class FeedbackViewModel
    {
        public string TalkId { get; set; }
        public string TalkName { get; set; }
        public string SpeakerId { get; set; }
        public string SpeakerName { get; set; }

        public IList<QuestionViewModel> Questionnaire { get; set; }
    }
}
