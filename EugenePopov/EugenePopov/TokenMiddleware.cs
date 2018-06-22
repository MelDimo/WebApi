using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EugenePopov
{
    public class TokenMiddleware
    {
        RequestDelegate next;
        string pattern;

        public TokenMiddleware(RequestDelegate pNext, string pPattern)
        {
            next = pNext;
            pattern = pPattern;
        }

        public async Task InvokeAsync(HttpContext pContext)
        {
            var token = pContext.Request.Query["token"];

            if (token != pattern)
            {
                pContext.Response.StatusCode = 403;
                await pContext.Response.WriteAsync("Token is invalid");
            }
            else
                await next(pContext);
        }
    }

    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder pBuilder, string pPattern)
        {
            return pBuilder.UseMiddleware<TokenMiddleware>(pPattern);
        }
    }
}
