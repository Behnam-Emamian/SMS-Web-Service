using SmsWebService.Models;

namespace SmsWebService.Interfaces
{
    public interface ISmsService
    {
        void Send(SMS sms);
    }
}
