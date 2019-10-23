using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmsWebService
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Task.Factory.StartNew(async () =>
            {
                var smsPermissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Sms);
                if (smsPermissionStatus != PermissionStatus.Granted)
                {
                    var smsPermissionRequestResult = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Sms);
                    if (smsPermissionRequestResult[Permission.Sms] != PermissionStatus.Granted)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            if (await DisplayAlert("SMS Permission", "Without SMS permission, the app is not working!!!", "Accept", "Cancel"))
                                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Sms);
                        });
                    }
                }
            })
        }
    }
}