using Plugin.Messaging;
using SmsWebService.Interfaces;
using SmsWebService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmsWebService.Controllers
{
    public class SMSController : WebApiController
    {
        public SMSController(IHttpContext context)
        : base(context)
        {
        }

        public override void SetDefaultHeaders() => HttpContext.NoCache();

        [WebApiHandler(HttpVerbs.Get, "/api/sms")]
        public async Task<bool> SendSMS()
        {
            //var sendSMSRequest = await HttpContext.ParseJsonAsync<SendSMSRequest>();
            var sendSMSRequest = new SendSMSRequest{
                Recipient = "",
                Message = "Hello from Xamarin"
            };

            DependencyService.Get<ISmsService>().Send(sendSMSRequest.Recipient, sendSMSRequest.Message);

            return await Ok("Message has been sent successfully.",contentType: "text/plain");
        }

    }
}
