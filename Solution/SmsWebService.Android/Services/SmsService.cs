using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using SmsWebService.Interfaces;
using SmsWebService.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(SmsWebService.Droid.Services.SmsService))]
namespace SmsWebService.Droid.Services
{
    class SmsService : ISmsService
    {
        public void Send(SMS sms)
        {
            SmsManager.Default.SendTextMessage(sms.Recipient, null, sms.Message, null, null);
        }
    }
}