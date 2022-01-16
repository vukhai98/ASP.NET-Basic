using ASP.NET06.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ASP.NET06.Service.SendMailService;

namespace ASP.NET06
{
    public class Startup
    {
        IConfiguration _configuration { set; get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var mailSettings = _configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailSettings);

            services.AddTransient<SendMailService>();
        }
        /* Mail Server - Smtp
         * SmtpClient
         * Sever: Mail Transporter (CenterOS /Qmail,SendMail)
         */
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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/SendMail", async context => {
                   var message = await MailUtils.MailUtils.SendMail("vuminhkhai27091998@gmail.com", "vuminhkhai27091998@gmail.com", "Test", "<h1>Hello</h1><p><My name is Khai</p>");
                    await context.Response.WriteAsync(message);
                });
                endpoints.MapGet("/SendGmail", async context => {
                    var message = await MailUtils.MailUtils.SendGmail("vuminhkhai27091998@gmail.com", "vuminhkhai27091998@gmail.com", "Test", "<h1>Hello</h1><i><My name is Khai</i>", "vuminhkhai27091998@gmail.com","Lonyeu12");
                    await context.Response.WriteAsync(message);
                });
                endpoints.MapGet("/TestSenddMailService", async context =>
                {
                    var sendMailService = context.RequestServices.GetService<SendMailService>();
                    var mailContent = new MailContent();

                    mailContent.To = "vuminhkhai27091998@gmail.com";
                    mailContent.Subject = " Test";
                    mailContent.Body = "<h1>TEST</h1><i>Hello VuChelsea</i>";
                    var result = await sendMailService.SendMail(mailContent);
                    await context.Response.WriteAsync(result);
                });
            });
        }
    }
}
