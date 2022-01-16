using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddRazorPages().AddRazorPagesOptions( option=> {
                option.RootDirectory = "/Pages";
                option.Conventions.AddPageRoute("/FristPage", "/PageOne.html"); // Thay duong dan cua Razor Page

            });
            services.Configure<RouteOptions>(routeOptions => {
                routeOptions.LowercaseUrls = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); 
                // FirstPage.cshtm URL = /FirstPage /SecondPage /ThirdPage

                // Services/service1

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
/*
    Razor page (.cshtml) = html + cs
    Engine Razor --> Bien dich cshtml -> Response for Client
    -@page "url"  is Rozor Pages
    -@bien,@(bieu thuc),@phuong thuc
    -@{
        
      }
    Rewirte URL
    @addTagHelper *,Microsoft.AspNet.Core.Mvc>TagHelpers
 */
