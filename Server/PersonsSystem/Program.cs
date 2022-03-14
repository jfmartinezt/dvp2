using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsSystem
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Debug()
       .WriteTo.Console()
       .WriteTo.File("Logs/.txt", rollingInterval: RollingInterval.Day)
       .CreateLogger();
        
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
