using CreatMiddleware.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SecondMiddleware>(); // Dang ki dich vu cho SecondMiddleware vi no trien khai tu IMiddleware
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); //StaticFileMiddleware
            //app.UseMiddleware<FirstMiddleware>();
            app.UseFirstMiddleware(); // Dua vao pipeline FirstMiddleware

            app.UseSecondMiddleware(); // Dua vao pipeline SecondMiddleware

            app.UseRouting();
            // Tao Endpoint(Terminate Middleware)

            //E1
            app.UseEndpoints(endpoint => {
                endpoint.MapGet("/about.html", async (context) => {
                    await context.Response.WriteAsync("Trang gioi thieu"); });
            });
            //E2
            app.UseEndpoints(endpoint => {
                endpoint.MapGet("/sanpham.html", async (context) => {
                    await context.Response.WriteAsync("Trang gioi thieu san pham"); });
            });

            // Terminate Middleware
            app.Run(async (context)=>{
                await context.Response.WriteAsync("Hello ASP.NET CORE 5");
            });

        }
    }
}
/*
 * HttpContext
 * Pipeline :FristMiddleware->SecondMiddleware -> M1
 */
