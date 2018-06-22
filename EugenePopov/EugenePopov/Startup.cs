using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EugenePopov.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EugenePopov
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IMessageSender, EmailMessageSender>();
            //services.AddTransient<TimeService>();
            //services.AddTransient<MessageService>();

            services.AddSingleton<ICounter, RandomCounter>();
            services.AddSingleton<CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IMessageSender env)
        //{
        //    app.UseMiddleware<ErrorHandingMiddleware>();
        //    app.UseMiddleware<AuthenticationMiddleware>();
        //    app.UseMiddleware<RoutingMiddleware>();
        //}

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
            //app.UseMiddleware<MesssageMiddlewsre>();
            //app.Run(async (context) =>
            //{
            //    MessageService sender = context.RequestServices.GetService<MessageService>();

            //    await context.Response.WriteAsync($"{sender?.SendMessage()} in {timeServ.GetTime()}");
            //});
        }
    }
}
