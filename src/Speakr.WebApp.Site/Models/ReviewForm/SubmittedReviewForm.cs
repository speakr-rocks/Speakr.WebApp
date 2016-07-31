using System.Collections.Generic;

namespace Speakr.WebApp.Site.Models.ReviewForm
{
    public class SubmittedReviewForm
    {
        public string TalkId { get; set; }
        public IList<ReviewFormQuestions> Questionnaire { get; set; }
    }
}
