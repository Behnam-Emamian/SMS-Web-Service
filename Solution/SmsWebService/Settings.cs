using Plugin.Settings;
using Plugin.Settings.Abstractions;

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
            get => AppSettings.GetValueOrDefault(nameof(PortNumber), "SecureApiKey");
            set => AppSettings.AddOrUpdateValue(nameof(PortNumber), value);
        }
    }
}
