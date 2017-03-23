using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Speakr.WebApp.Site.Clients.TalksApi;

namespace Speakr.WebApp.Site.AppStart
{
    public class IoCRegistry
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITalksApi>(ApiClient => new TalksApi("http://talksapi.speakr.rocks"));
        }
    }
}
