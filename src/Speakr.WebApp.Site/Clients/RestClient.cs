using System.Net.Http;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients
{
    public class RestClient
    {
        public async Task<string> Get(string baseUrl)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync("http://localhost:5000/api/greeting");
            }
        }

        public async Task<HttpResponseMessage> Post(string baseUrl, T)
        {
            using (var client = new HttpClient())
            {
                return await client.PostAsync("http://localhost:5000/api/greeting");
            }
        }
    }
}
