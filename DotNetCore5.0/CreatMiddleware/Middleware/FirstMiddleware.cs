using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatMiddleware.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        //RequestDelegate ~async(HttpContext context) =>{};
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //Http Context di qua cac Middleware trong pipeline
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"URL: {context.Request.Path}");
            context.Items.Add("Data FirstMiddleware", $"<p>URL: {context.Request.Path}</p>");
            //await context.Response.WriteAsync($"<p>URL: {context.Request.Path}</p>");
            await _next(context);

        }
    }
}
