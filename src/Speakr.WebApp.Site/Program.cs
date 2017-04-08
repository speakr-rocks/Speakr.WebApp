﻿using System.IO;
using Microsoft.AspNetCore.Hosting;
using Speakr.WebApp.Site.AppStart;

namespace Speakr.WebApp.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
