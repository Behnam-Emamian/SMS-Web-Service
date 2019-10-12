using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;
using SmsWebService.Controllers;

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
                using (var server = new WebServer("http://*:8080"))
                {
                    server.RegisterModule(new CorsModule());
                    server.WithWebApiController<HealthCheckController>(true);
                    server.WithWebApiController<SMSController>(true);

                    await server.RunAsync();
                }
            });

            MainPage = new MainPage();
        }
    }
}
