using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.Models.ReviewForm
{
    public class ReviewFormResponse
    {
        public string ReviewerId { get; set; }
        public IList<ReviewFormQuestions> Questionnaire { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}
