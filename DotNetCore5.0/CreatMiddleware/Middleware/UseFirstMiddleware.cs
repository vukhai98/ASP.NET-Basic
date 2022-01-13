using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatMiddleware.Middleware
{
    public static class UseFirstMiddlewareMethod
    {
        public static void  UseFirstMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
    }
    public static class UseSecondMiddlewareMethod
    {
        public static void UseSecondMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
    }
}
