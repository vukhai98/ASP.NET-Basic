﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace AppMVC.Net
{
    public static class AppExtends
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>
            {
                appError.Run(async context =>
                {
                    var respone = context.Response;
                    var code = respone.StatusCode;

                    var content = @$"<html>
                        <head>
                            <meta charset='UTF8'/>
                            <title>Lỗi{code}</title>
                        </head>
                        <body>
                            <p style ='color:red; font-size:30px'>
                                  Có lỗi xảy ra: {code}-{(HttpStatusCode)code}
                            </p>
                        </body>
                    </html>";

                    await respone.WriteAsync(content);

                });
            }); //Code 400-599

        }
    }
}
