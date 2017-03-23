using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Speakr.WebApp.Site.AppStart;

namespace Speakr.WebApp.AppStart
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) { }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Configuration.Configure();

            IoCRegistry.RegisterDependencies(services, configuration);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseMvc();
        }
    }
}
