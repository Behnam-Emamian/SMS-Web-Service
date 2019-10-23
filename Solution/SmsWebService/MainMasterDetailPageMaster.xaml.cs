using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmsWebService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MainMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public MainMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMasterDetailPageMasterMenuItem>(new[]
                {
                    new MainMasterDetailPageMasterMenuItem { Id = 0, Title = "Home", TargetType=typeof(MainPage) },
                    new MainMasterDetailPageMasterMenuItem { Id = 1, Title = "Inbox", TargetType=typeof(MainMasterDetailPageDetail) },
                    new MainMasterDetailPageMasterMenuItem { Id = 1, Title = "Outbox", TargetType=typeof(MainMasterDetailPageDetail) },
                    new MainMasterDetailPageMasterMenuItem { Id = 3, Title = "Logs", TargetType=typeof(MainMasterDetailPageDetail) },
                    new MainMasterDetailPageMasterMenuItem { Id = 4, Title = "Settings", TargetType=typeof(SettingsPage) },
                    new MainMasterDetailPageMasterMenuItem { Id = 2, Title = "About", TargetType=typeof(MainMasterDetailPageDetail) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}