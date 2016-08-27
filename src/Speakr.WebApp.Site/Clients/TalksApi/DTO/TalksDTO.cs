using System.Collections.Generic;

namespace Speakr.WebApp.Site.Clients.TalksApi.DTO
{
    public class TalksDTO
    {
        public string TalkId { get; set; }
        public string TalkName { get; set; }
        public string SpeakerId { get; set; }
        public string SpeakerName { get; set; }
        public IList<Question> Questionnaire { get; set; }
    }
}
