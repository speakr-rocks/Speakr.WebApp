using Microsoft.Extensions.Configuration;

namespace Speakr.WebApp.Infrastructure
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private IConfigurationRoot _configuration;

        public AppSettingsProvider(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public string DefaultHealthString { get { return GetDefaultHealthString(); } }

        private string GetDefaultHealthString()
        {
            return _configuration["DefaultHealthString"];
        }
    }
}
