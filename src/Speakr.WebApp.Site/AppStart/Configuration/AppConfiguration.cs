using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Speakr.WebApp.Site.AppStart.Configuration
{
    public static class AppConfiguration
    {
        public static IConfigurationRoot Configure(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("auth0.json", optional: false)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
