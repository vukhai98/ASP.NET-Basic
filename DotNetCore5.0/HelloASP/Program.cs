using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASP
{
    public class Program
    {
        /*
         *  Host(IHost) object:
                - Dependency Injection (DI): ISeverProvider (ServiceCollection) 
                - Logging (ILogging)
                - Configuration
                - IHostedService => StartAsync: Run HTTP Server (Kestrel Http)

            1) IHostBuilder
            2) Cau hinh, dang ky dich vu (goi ConfigureWebHostDefaults)
            3, IHostBuilder.Build() => Host (IHost)
            4, Host.Run();
            
            Request => pipeLine(Middleware)
         */
        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Start App");
        //    IHostBuilder builder = Host.CreateDefaultBuilder(args);
        //    // Cau hinh mac dinh cho HOST tao ra

        //    builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) => {
        //        // Tuy bien them ve Host
        //        // WebBuilder.
        //        webBuilder.UseStartup<MyStartUp>();
        //    });
        //    IHost host = builder.Build();
        //    host.Run();


        //}
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<MyStartUp>();
                });
    }
}
