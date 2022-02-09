using AppMVC.Net.Models;
using AppMVC.Net.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace AppMVC.Net
{
    public class Startup
    {
        public static string CotentRoothPath { set; get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CotentRoothPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => {
                string connectString = Configuration.GetConnectionString("AppMvcConnectionString");
                options.UseSqlServer(connectString);    
            });
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<RazorViewEngineOptions>(options=>{
                //   /View/Controller/Action.cshtml
                //   /MyView/Controller/Action.cshtml

                //{0} -> ten Action
                //{1} -> ten Controller
                //{2} -> ten Area

                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddSingleton<ProductServices, ProductServices>();
            services.AddSingleton<PlantService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.AddStatusCodePage(); // Tuy biến respone khi có lỗi từ 400 -> 599

            app.UseRouting(); // EnpointRoutingMiddleware

            app.UseAuthentication(); // Xác định danh tính


            app.UseAuthorization(); //  Xác thực  quyền truy cập

            app.UseEndpoints(endpoints =>
            {

            //sayhi
            endpoints.MapGet("/sayhi", async (context) =>
            {
                await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
            });

            //endpoints.MapControllers
            //endpoints.MapAreaControllerRoute
            //endpoints.MapControllerRoute
            //endpoints.MapDefaultControllerRoute

            //[AcceptVerbs]

            //[Route]
            //[HttpGet]
            //[HttpPost]
            //[HttpPut]
            //[HttpDelete]
            //[HttpHead]
            //[HttpPatch]

            endpoints.MapControllerRoute(
                name: "first",
                pattern: "{url:regex(^(xemsanpham)|(viewproduct)$)}/{id:range(2,4)}",
                defaults: new
                {
                    controller = "First",
                    action = "ViewProduct"
                }
                );

            endpoints.MapAreaControllerRoute(
                name:"product",
                pattern: "/{controller=Home}/{action=Index}/{id?}",
                areaName: "ProductManage"

                );


                // Controller không có Area
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapRazorPages();
            });

        }
    }
}
