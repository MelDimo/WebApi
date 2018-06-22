using EugenePopov.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EugenePopov
{
    public class CounterMiddleware
    {
        int i = 0;

        public CounterMiddleware(RequestDelegate next)
        {

        }

        public async Task InvokeAsync(HttpContext context, ICounter counter, CounterService counterSrvice)
        {
            i++;
            await context.Response.WriteAsync($"Request: {i} ICounter: {counter.Value}" +
                $" CounterSrvice: {counterSrvice.Counter.Value}");
        }
    }
}
