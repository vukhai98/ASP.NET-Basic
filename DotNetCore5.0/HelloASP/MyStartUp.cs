using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HelloASP
{
    public class MyStartUp
    {
        //Dang ki cac dich vu cau ung dung(DI)
        public void ConfigureServices(IServiceCollection services)
        {

        }
        // Xay dung pipeline(chuoi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //StaticFileMiddleware
            // wwwroot
            app.UseStaticFiles();
            //Request
            //EndpointRoutingMiddleware
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/", async (context) => {
                    string html = @" <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>


                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                            <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                        </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>
    ";
                    await context.Response.WriteAsync(html);

                 
                });
                endpoints.MapGet("/about", async (context) => {
                    await context.Response.WriteAsync("Trang gioi thieu");
                });
                endpoints.MapGet("/contact", async (context) => {
                    await context.Response.WriteAsync("Trang lien he");
                });
            });

            //Terminate Middleware
            app.Map("/abc", app1 => {
                app1.Run(async (context) => {
                    await context.Response.WriteAsync("Noi dung cha ve abc");
                });
            });

            //StatusCodePages
            app.UseStatusCodePages();

            ////Terminate Middleware
            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Xin chao day la MyStartup");
            //});

            
        }
    }
}
