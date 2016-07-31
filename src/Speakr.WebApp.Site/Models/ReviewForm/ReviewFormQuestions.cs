using Speakr.WebApp.Site.Models.Talks;
using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.Models.ReviewForm
{
    public class ReviewFormQuestions
    {
        public string QuestionId { get; set; }
        public string Question { get; set; }
        public ResponseTypes ResponseType { get; set; }

        [MaxLength(255)]
        public string Answer { get; set; }
    }
}
