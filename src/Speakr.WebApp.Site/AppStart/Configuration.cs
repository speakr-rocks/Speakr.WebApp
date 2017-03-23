using Microsoft.Extensions.Configuration;

namespace Speakr.WebApp.Site.AppStart
{
    public class Configuration
    {
        public static IConfigurationRoot Configure()
        {
            var builder = new ConfigurationBuilder();

            return builder.Build();
        }
    }
}
