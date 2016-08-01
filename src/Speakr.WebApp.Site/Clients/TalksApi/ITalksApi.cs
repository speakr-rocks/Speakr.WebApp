using Speakr.WebApp.Site.Clients.TalksApi.DTO;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients.TalksApi
{
    public interface ITalksApi
    {
        Task<TalksDTO> GetTalkById(string talkId);
        Task PostReviewResponse(string talkdId, FeedbackDTO response);
    }
}