using ASP.DOTNET03.mylib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
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
                var html = HtmlHelper.HtmlDocument("Xin Chao", menu + HtmlHelper.HtmlTrangchu());
                await context.Response.WriteAsync(html);
            });

            endpoints.MapGet("/RequestInfo", async (context) =>
            {
               var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request).HtmlTag("div","container");

                //context.Request
               var info =RequestProcess.RequestInfo(context.Request);
               var html = HtmlHelper.HtmlDocument("Thong tin Request", menu + info  ).HtmlTag("div","container");

                await context.Response.WriteAsync(html);
            });
            
            endpoints.MapGet("/Encoding", async (context) =>
            {
                await context.Response.WriteAsync("Encoding");
            });
            
            // Cookie/write
            // Cookie/read
            endpoints.MapGet("/Cookies/{*action}", async (context) =>
            {
                var menu = HtmlHelper.MenuTop(
                    HtmlHelper.DefaultMenuTopItems(), context.Request);

                var action =context.GetRouteValue("action")??"read";

                var message = "";
                if (action.ToString()=="write")
                {
                    //  key - value
                    var option = new CookieOptions()
                    {
                        Path = "/",
                        Expires = DateTime.Now.AddDays(1)
                    };
                    context.Response.Cookies.Append("Masanpham", "12334444",option);
                    message = "Cookie duoc ghi";

                }
                else
                {
                    // Lấy danh sách các Header và giá trị  của nó, dùng Linq để lấy
                    var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
                    message = string.Join("", listcokie).HtmlTag("ul");
                }
                var huongdan = "<a class=\"btn btn-danger\" href=\"/Cookies/read\">Read Cooki</a><a class=\"btn btn-success\" href=\"/Cookies/write\">Write Cookie</a>";
                huongdan = huongdan.HtmlTag("div", "container mt-4 ");
                message = message.HtmlTag("div", "alert alert-danger");
                var html = HtmlHelper.HtmlDocument("Cookie:" + action , menu + huongdan + message);

                await context.Response.WriteAsync(html);
            });

            endpoints.MapGet("/Json", async (context) =>
            {
                var p = new
                {
                    ProductName = "Iphone13 Promax",
                    Gia = "2000$",
                    EXS = new DateTime(2021, 8, 30)
                };
                context.Response.ContentType = "application/json";

                var json = JsonConvert.SerializeObject(p);
                    
                await context.Response.WriteAsync(json);
            });
            endpoints.MapMethods("/Form", new string[] {"POST","GET" }, async (context) =>
            {
                var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);

                //context.Request
                var info = RequestProcess.RequestInfo(context.Request);

                var formHtml = RequestProcess.ProcessForm(context.Request);

                var html = HtmlHelper.HtmlDocument("Test submit form html", menu + formHtml);

                await context.Response.WriteAsync(html);
            });
        }
    }
}
