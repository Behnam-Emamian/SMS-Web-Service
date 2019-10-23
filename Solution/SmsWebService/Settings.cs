using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Net;
using System.Linq;

namespace SmsWebService
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static int PortNumber
        {
            get => AppSettings.GetValueOrDefault(nameof(PortNumber), 8767);
            set => AppSettings.AddOrUpdateValue(nameof(PortNumber), value);
        }

        public static string ApiKey
        {
            get => AppSettings.GetValueOrDefault(nameof(ApiKey), "SecureApiKey");
            set => AppSettings.AddOrUpdateValue(nameof(ApiKey), value);
        }

        public static string IpAddress
        {
            get => Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault()?.ToString();
        }

        public static string HostingUrl
        {
            get => $"http://*:{PortNumber}";
        }
    }
}
