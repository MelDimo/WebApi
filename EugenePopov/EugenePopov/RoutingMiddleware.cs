using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EugenePopov
{
    public class RoutingMiddleware
    {
        RequestDelegate next;

        public RoutingMiddleware(RequestDelegate pNext)
        {
            next = pNext;
        }

        public async Task InvokeAsync(HttpContext pContext)
        {
            string path = pContext.Request.Path.Value.ToLower();

            if (path == "/" || path == "/index")
            {
                await pContext.Response.WriteAsync("HomePage");
            }
            else
                if (path == "/about")
                await pContext.Response.WriteAsync("About");
            else
                pContext.Response.StatusCode = 404;

        }
    }
}
