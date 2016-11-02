using System.Net.Http;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients
{
    public abstract class RestClient
    {

        private string _baseUrl;

        public RestClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<string> Get(string baseUrl)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(_baseUrl);
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
