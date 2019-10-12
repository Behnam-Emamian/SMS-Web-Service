using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

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
            return await Ok("Healthy.",contentType: "text/plain");
        }

    }
}
