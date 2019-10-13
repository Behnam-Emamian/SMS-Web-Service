using System;
using System.Collections.Generic;
using System.Text;

namespace SmsWebService.Interfaces
{
    public interface ISmsService
    {
        void Send(string recipient, string message);
    }
}
