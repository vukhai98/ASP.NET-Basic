using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatMiddleware.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        /*
         * Neu URL:"/xxx.html"
         * - Khong goi Middleware phia sau 
         * - Ban khong duoc truy cap
         * Header- SecondMiddleware: Ban khong duoc truy cap
         * Neu != URL: "xxx.html"
         * - Header - SeconMiddleware: Ban duoc truy cap
         * - Chuyen HttpContext cho Middleware phia sau 
         */
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                var dataFromFirstMiddleware = context.Items["Data FirstMiddleware"];
                if (dataFromFirstMiddleware != null)
                {
                    await context.Response.WriteAsync((string)dataFromFirstMiddleware);
                }
                await context.Response.WriteAsync("Ban khong truy cap duoc");
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                await next(context);
            }
        }
    }
}
