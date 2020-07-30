using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class WhatsappResponse
    {
        public string scenarioKey { set; get; }

        public List<Destination> destinations { set; get; } = new List<Destination>();

        public WhatsApp whatsApp { set; get; }
    }


    public class SmsResponse
    {
        public string scenarioKey { set; get; }

        public List<Destination> destinations { set; get; } = new List<Destination>();

        public Sms sms { set; get; }
    }

    public class WhatsApp
    {
        public string text { set; get; }
    }

    public class Sms
    {
        public string text { set; get; }
    }

    public class Destination
    {
        public To to { set; get; } = new To();
    }

    public class To
    {
        public string phoneNumber { get; set; }

    }

    public class Status
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

    }

    public class Message
    {
        public To to { get; set; }
        public Status status { get; set; }
        public string messageId { get; set; }

    }

    public class ServiceException
    {
        public string messageId { get; set; }
        public string text { get; set; }

    }

    public class RequestError
    {
        public ServiceException serviceException { get; set; }

    }

    public class Root
    {
        public List<Message> messages { get; set; }
        public RequestError requestError { get; set; }

    }
}
