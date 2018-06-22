using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EugenePopov
{
    public class AuthenticationMiddleware
    {
        RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate pNext)
        {
            next = pNext;
        }

        public async Task InvokeAsync(HttpContext pContext)
        {
            var token = pContext.Request.Query["token"];
            if (String.IsNullOrEmpty(token))
            {
                pContext.Response.StatusCode = 403; // Access denied
            }
            else
                await next(pContext);
        }
    }
}
