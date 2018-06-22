using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EugenePopov.Services
{
    public class MesssageMiddlewsre
    {
        RequestDelegate next;

        public MesssageMiddlewsre(RequestDelegate pNext)
        {
            next = pNext;
        }

        public async Task InvokeAsync(HttpContext pContext, MessageService pSender)
        {
            await pContext.Response.WriteAsync(pSender.SendMessage());
        }
    }

    public class MessageService
    {
        IMessageSender sender;

        public MessageService(IMessageSender pSender)
        {
            sender = pSender;
        }
        public string SendMessage()
        {
            return sender.Send();
        }
    }

    public interface IMessageSender
    {
        string Send();
    }

    public class EmailMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Message is send by email";
        }
    }

    public class SmsMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Message is send by sms";
        }
    }
}
