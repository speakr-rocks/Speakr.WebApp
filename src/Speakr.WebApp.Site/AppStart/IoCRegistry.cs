using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Speakr.WebApp.Site.Clients.TalksApi;

namespace Speakr.WebApp.Site.AppStart
{
    public class IoCRegistry
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddSingleton<ITalksApi>(ApiClient => new TalksApi("http://localhost:54826"));
            }
            else
            {
                services.AddSingleton<ITalksApi>(ApiClient => new TalksApi("http://talksapi.speakr.rocks"));
            }
        }
    }
}
