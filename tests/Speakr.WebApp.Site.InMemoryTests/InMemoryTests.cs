﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using NUnit.Framework;
using System.IO;

namespace Speakr.WebApp.Site.Tests
{
    public class InMemoryTests
    {
        private HttpClient _client;
        private TestServer _server;

        [SetUp]
        public void SetupInMemoryHost()
        {
            _server = new TestServer(
                new WebHostBuilder()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public void HomeControllerIndexShouldNotBeNull()
        {
            Assert.That(_client.GetAsync("/"), Is.Not.Null);
        }

    }
}
