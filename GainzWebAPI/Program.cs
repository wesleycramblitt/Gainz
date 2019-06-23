using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GainzWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

                var config = new ConfigurationBuilder().AddCommandLine(args).Build();
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseConfiguration(config)
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            

        }
        //This is only for EF migrations
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
              .ConfigureAppConfiguration((ctx, cfg) =>
              {
                  cfg.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json", true) // require the json file!
                    .AddEnvironmentVariables();
              })
              .ConfigureLogging((ctx, logging) => { }) // No logging
              .UseStartup<Startup>()
              .UseSetting("DesignTime", "true")
              
              .Build();
        }



    }
}
