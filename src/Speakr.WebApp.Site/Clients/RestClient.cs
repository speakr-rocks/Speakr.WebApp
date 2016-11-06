using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Clients
{
    public abstract class RestClient
    {
        protected static HttpClient _httpClient;
        private static string _baseUrl;

        public RestClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var responseMessage = await _httpClient.GetAsync($"{_baseUrl}/{uri}");
            return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<HttpResponseMessage> Post(string uri, dynamic body)
        {
            var jsonObject = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync($"{_baseUrl}/{uri}", content);
        }
    }
}
