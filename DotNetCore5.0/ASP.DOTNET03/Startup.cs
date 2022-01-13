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

namespace ASP.DOTNET03
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Test1(endpoints);
                Test2(endpoints);
            });
        }

        private void Test1(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/", async context =>
            {
                var menuObj = new object[]
                    {
                            new
                            {
                                url = "/abc",
                                label ="Menu abc"
                            },
                             new
                            {
                                url = "/xyz",
                                label ="Menu xyz"
                            } };
                var menu = HtmlHelper.MenuTop(menuObj, context.Request);
                var html = HtmlHelper.HtmlDocument("Xin Chao", menu + "Hello World!".HtmlTag("h1", "text-danger"));
                await context.Response.WriteAsync(html);
            });
            endpoints.MapGet("/RequestInfo", async (context) =>
            {
                await context.Response.WriteAsync("ResquestInfo");
            });
            endpoints.MapGet("/Endcoding", async (context) =>
            {
                await context.Response.WriteAsync("Endcoding");
            });
            endpoints.MapGet("/Cookies", async (context) =>
            {
                await context.Response.WriteAsync("Cookies");
            });
            endpoints.MapGet("/Json", async (context) =>
            {
                await context.Response.WriteAsync("Json");
            });
            endpoints.MapGet("/Form", async (context) =>
            {
                await context.Response.WriteAsync("Form");
            });
        }

        private void Test2(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/", async context =>
            {
                var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);              
                var html = HtmlHelper.HtmlDocument("Xin Chao", menu + "Hello World!".HtmlTag("h1", "text-danger"));
                await context.Response.WriteAsync(html);
            });
            endpoints.MapGet("/RequestInfo", async (context) =>
            {
                await context.Response.WriteAsync("ResquestInfo");
            });
            endpoints.MapGet("/Encoding", async (context) =>
            {
                await context.Response.WriteAsync("Encoding");
            });
            endpoints.MapGet("/Cookies", async (context) =>
            {
                await context.Response.WriteAsync("Cookies");
            });
            endpoints.MapGet("/Json", async (context) =>
            {
                await context.Response.WriteAsync("Json");
            });
            endpoints.MapGet("/Form", async (context) =>
            {
                await context.Response.WriteAsync("Form");
            });
        }
    }
}
