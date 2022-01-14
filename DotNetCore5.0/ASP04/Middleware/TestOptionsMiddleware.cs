using ASP04.Options;
using ASP04.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP04.Middleware
{
    public class TestOptionsMiddleware : IMiddleware
    {
        TestOptions _testOptions { set; get; }
        ProductNames productNames { set; get; }
        public TestOptionsMiddleware(IOptions<TestOptions> options, ProductNames product)
        {
           _testOptions = options.Value;
            productNames = product;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Show options in TestOptionsMiddlewarw\n");
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("TESTOPION\n");
            stringBuilder.Append($"out_key1= {_testOptions.opt_key1}\n");
            stringBuilder.Append($"TestOption.out_key2.k1= {_testOptions.opt_key2.k1}\n");
            stringBuilder.Append($"TestOption.out_key2.k2= {_testOptions.opt_key2.k2}\n");

            foreach (var item in productNames.GetNames())
            {
                stringBuilder.Append(item + "\n");
            }
            await context.Response.WriteAsync(stringBuilder.ToString());
            await next(context);
        }
    }
}
