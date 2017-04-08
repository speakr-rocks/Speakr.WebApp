using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using NUnit.Framework;
using Speakr.WebApp.Site.AppStart;
using System.Threading.Tasks;

namespace Speakr.WebApp.Site.Tests
{
    public class InMemoryTests
    {
        private HttpClient _client;
        private TestServer _server;

        [SetUp]
        public void SetupInMemoryHost()
        {
            _server = new TestServer(new WebHostBuilder()
                    .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Test]
        [Ignore("Find out how to mock Auth0 and pass in dummy Auth0 creds via appsettings")]
        public async Task HomeControllerIndexShouldNotBeNull()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.That(responseString, Is.Not.Null);
        }

    }
}
