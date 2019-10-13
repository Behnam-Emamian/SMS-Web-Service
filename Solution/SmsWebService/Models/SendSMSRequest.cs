using System;
using System.Collections.Generic;
using System.Text;

namespace SmsWebService.Models
{
    class SendSMSRequest
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
        public bool DeliverCheck { get; set; }
    }
}
