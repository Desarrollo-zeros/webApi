using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebApi.Models;

namespace WebApi.Controllers
{

   


    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [HttpPost("message")]
        public ActionResult<dynamic> Message(SendRequest sendRequest)
        {
            var client = new RestClient("https://4mmdvn.api.infobip.com/omni/1/advanced");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Basic QWRtaW5pc3RyYWRvci5EZXJjbzpXYS4yODkzNCo=");
            request.AddHeader("content-type", "application/json");

            IRestResponse response;

            dynamic data;
            if (sendRequest.Type == 1)
            {

                var WhatSapp = new WhatsappResponse()
                {
                    scenarioKey = "B140C6E021C207FEB2CDE5F1DC874482",
                    whatsApp = new WhatsApp
                    {
                        text = sendRequest.Message
                    }
                };
                WhatSapp.destinations = new List<Destination>
                {
                    new Destination
                    {
                        to = new To
                        {
                            phoneNumber =  sendRequest.Number
                        }
                    }
                };
                string jsonString;
                jsonString = JsonSerializer.Serialize(WhatSapp);
               
                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                request.Method = Method.POST;
                response = client.Execute(request);

                data = WhatSapp;

            }
            else
            {
                var sms = new SmsResponse()
                {
                    scenarioKey = "B140C6E021C207FEB2CDE5F1DC874482",
                    sms = new Sms
                    {
                        text = sendRequest.Message
                    }
                };
                sms.destinations = new List<Destination>
                {
                    new Destination
                    {
                        to = new To
                        {
                            phoneNumber =  sendRequest.Number
                        }
                    }
                };
                string jsonString;
                jsonString = JsonSerializer.Serialize(sms);

                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                request.Method = Method.POST;
                response = client.Execute(request);
                data = sms;
            }

            Root myDeserializedClass = JsonSerializer.Deserialize<Root>(response.Content); 
            var r = new
            {
                Data = data,
                Message = myDeserializedClass.messages,
                Error = myDeserializedClass.requestError,
                Status = response.StatusCode,
            };

            return r;
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [HttpGet("message/{number}/{message}/{type}")]
        public ActionResult<dynamic> Message(string number, string message, short type)
        {

            SendRequest sendRequest = new SendRequest
            {
                Message = message,
                Number = number,
                Type = type
            };

            var client = new RestClient("https://4mmdvn.api.infobip.com/omni/1/advanced");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Basic QWRtaW5pc3RyYWRvci5EZXJjbzpXYS4yODkzNCo=");
            request.AddHeader("content-type", "application/json");

            IRestResponse response;

            dynamic data;
            if (sendRequest.Type == 1)
            {

                var WhatSapp = new WhatsappResponse()
                {
                    scenarioKey = "B140C6E021C207FEB2CDE5F1DC874482",
                    whatsApp = new WhatsApp
                    {
                        text = sendRequest.Message
                    }
                };
                WhatSapp.destinations = new List<Destination>
                {
                    new Destination
                    {
                        to = new To
                        {
                            phoneNumber =  sendRequest.Number
                        }
                    }
                };
                string jsonString;
                jsonString = JsonSerializer.Serialize(WhatSapp);

                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                request.Method = Method.POST;
                response = client.Execute(request);

                data = WhatSapp;

            }
            else
            {
                var sms = new SmsResponse()
                {
                    scenarioKey = "B140C6E021C207FEB2CDE5F1DC874482",
                    sms = new Sms
                    {
                        text = sendRequest.Message
                    }
                };
                sms.destinations = new List<Destination>
                {
                    new Destination
                    {
                        to = new To
                        {
                            phoneNumber =  sendRequest.Number
                        }
                    }
                };
                string jsonString;
                jsonString = JsonSerializer.Serialize(sms);

                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                request.Method = Method.POST;
                response = client.Execute(request);
                data = sms;
            }

            Root myDeserializedClass = JsonSerializer.Deserialize<Root>(response.Content);
            var r = new
            {
                Data = data,
                Message = myDeserializedClass.messages,
                Error = myDeserializedClass.requestError,
                Status = response.StatusCode,
            };

            return r;
        }



    }
}