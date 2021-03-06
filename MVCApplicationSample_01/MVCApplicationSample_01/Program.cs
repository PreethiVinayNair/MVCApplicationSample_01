using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;


namespace MVCApplicationSample_01
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
      try
      {
        CreateHostBuilder(args).Build().Run();
      }
      catch (Exception ex)
      {
        logger.Error(ex, "Stopped program because of exception");
        throw;
      }
      finally
      {
        // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
        LogManager.Shutdown();
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>()
              .CaptureStartupErrors(true)
              .UseSetting("detailedErrors", "true")
            .ConfigureLogging(logging =>
            {
              logging.ClearProviders();
              // Logging configuration specified in appsettings.json overrides any call to SetMinimumLevel
              logging.SetMinimumLevel(LogLevel.Trace);
            })
            .UseNLog(); 
            });
  }
}
