using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmsWebService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            ipEntry.Text = Settings.IpAddress;
            portEntry.Text = Settings.PortNumber.ToString();
            apiKeyEntry.Text = Settings.ApiKey;
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            Settings.PortNumber = int.Parse(portEntry.Text);
            Settings.ApiKey = apiKeyEntry.Text;
        }

        
    }    
}