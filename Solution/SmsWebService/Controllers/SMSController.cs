using Plugin.Messaging;
using SmsWebService.Interfaces;
using SmsWebService.Models;
using System;
using System.Collections.Generic;
using System.Net;
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

        [WebApiHandler(HttpVerbs.Post, "/api/sms")]
        public async Task<bool> SendSMS()
        {
            if (!HttpContext.HasRequestHeader("ApiKey"))
                return await InternalServerError(new UnauthorizedAccessException("ApiKey is not provided!"), HttpStatusCode.Unauthorized);

            if (HttpContext.RequestHeader("ApiKey")!=Settings.ApiKey)
                return await InternalServerError(new UnauthorizedAccessException("ApiKey is not correct!"), HttpStatusCode.Unauthorized);

            var sms = await HttpContext.ParseJsonAsync<SMS>();
            if (string.IsNullOrEmpty(sms.Recipient))
                return await InternalServerError(new ArgumentNullException("Recipient"), HttpStatusCode.BadRequest);

            if (string.IsNullOrEmpty(sms.Message))
                return await InternalServerError(new ArgumentNullException("Message"), HttpStatusCode.BadRequest);

            //DependencyService.Get<ISmsService>().Send(sms);

            return await Ok("{ \"Message\": \"SMS has been sent successfully.\" }");
        }

    }
}
