using System.ComponentModel.DataAnnotations;

namespace Speakr.WebApp.Site.ViewModels.Home
{
    public class CheckTalkIdViewModel
    {
        [Required, MinLength(4), MaxLength(25)]
        public string TalkId { get; set; }
    }
}
