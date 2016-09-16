using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.ViewModels.Home
{
    public class GetFeedbackFormViewModel
    {
        [MaxLength(24)]
        [Display(Name = "Talk Id:")]
        [Required(ErrorMessage = "Please enter your talk's ID")]
        [MinLength(4, ErrorMessage = "Talk ID's have at least 4 characters")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Please use alphanumeric characters only")]
        public string TalkId { get; set; }

        public string TalkIdErrorMessage { get; set; }

        public bool HasErrors { get { return !string.IsNullOrEmpty(TalkIdErrorMessage); } }
    }
}
