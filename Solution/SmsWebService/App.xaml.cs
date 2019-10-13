using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;
using SmsWebService.Controllers;
using System.Reflection;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmsWebService
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            Task.Factory.StartNew(async () =>
            {
                using (var server = new WebServer("http://*:"+ Settings.PortNumber))
                {
                    server.RegisterModule(new LocalSessionModule());

                    server.RegisterModule(new CorsModule());
                    server.WithWebApiController<HealthController>(true);
                    server.WithWebApiController<SMSController>(true);

                    Assembly assembly = typeof(App).Assembly;
                    server.RegisterModule(new ResourceFilesModule(assembly, "SmsWebService.swagger"));

                    await server.RunAsync();
                }
            });

            MainPage = new MainPage();
        }
    }
}
