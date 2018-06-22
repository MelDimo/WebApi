using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EugenePopov
{
    public class ErrorHandingMiddleware
    {
        RequestDelegate next;

        public ErrorHandingMiddleware(RequestDelegate pNext)
        {
            next = pNext;
        }

        public async Task InvokeAsync(HttpContext pContext)
        {
            await next(pContext);

            switch (pContext.Response.StatusCode)
            {
                case 403:
                    await pContext.Response.WriteAsync("Access Denied");
                    break;

                case 404:
                    await pContext.Response.WriteAsync("Not Found");
                    break;
            }
        }
    }
}
