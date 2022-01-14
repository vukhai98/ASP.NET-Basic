using ASP04.Middleware;
using ASP04.Options;
using ASP04.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP04
{
    public class Startup
    {
        IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TestOptionsMiddleware>();
            services.AddSingleton<ProductNames>();
            services.AddOptions();
             var testOption = _configuration.GetSection("TestOptions");
            services.Configure<TestOptions>(testOption);

            //IOptions<TestOption>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<TestOptionsMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/ShowOptions", async (context) =>
                {

                    //var configuration = context.RequestServices.GetService<IConfiguration>();

                    //var testOptions = configuration.GetSection("TestOptions").Get<TestOptions>();

                    //var opt_key1 = testOptions["opt_key1"];

                    //var k1 = testOptions.GetSection("opt_key2")["k1"];
                    //var k2 = testOptions.GetSection("opt_key2")["k2"];

                    //var testOptions = context.RequestServices.GetService<IOptions<TestOptions>>().Value;

                    //var stringBuilder = new StringBuilder();

                    //stringBuilder.Append("TESTOPION\n");
                    //stringBuilder.Append($"out_key1= {testOptions.opt_key1}\n");
                    //stringBuilder.Append($"TestOption.out_key2.k1= {testOptions.opt_key2.k1}\n");
                    //stringBuilder.Append($"TestOption.out_key2.k2= {testOptions.opt_key2.k2}\n");

                    //await context.Response.WriteAsync(stringBuilder.ToString());
                    await context.Response.WriteAsync("Show Option");



                });

            });
        }
    }
}
