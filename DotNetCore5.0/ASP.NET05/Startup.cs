using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET05
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.Cookie.Name = "cookie1";
                option.IdleTimeout = new TimeSpan(0, 30, 0); //timeout = 30m
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession(); //SessionMiddleware - Cookie (ID Session)

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    int? count; //count

                    count = context.Session.GetInt32("count"); //Doc Session

                    if (count == null)
                    {
                        count = 0;

                    }
                    count += 1;
                    context.Session.SetInt32("cookie1", 3333);

                    context.Session.SetInt32("count", count.Value); // Luu Session
                    await context.Response.WriteAsync($"So lan truy cap readwritesession la :{count}");
                    await context.Response.WriteAsync("Hello World!");
                });


                endpoints.MapGet("/readsession", async context =>
                {


                    int? count; //count

                    count = context.Session.GetInt32("count"); //Doc Session

                    if (count == null)
                    {
                        count = 0;

                    }
                    count += 1;

                    context.Session.SetInt32("count", count.Value); // Luu Session
                    await context.Response.WriteAsync($"So lan truy cap readwritesession la :{count}");

                });
            });
        }
    }
}
