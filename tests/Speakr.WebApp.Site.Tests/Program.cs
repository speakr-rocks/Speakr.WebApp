using NUnitLite;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Speakr.WebApp.Site.Tests
{
    class Program
    {
        public static int Main(string[] args)
        {
            return new AutoRun(typeof(Program).GetTypeInfo().Assembly).Execute(args);
        }
    }
}
