using System;
using CarRentalCompany.App.Application;
using CarRentalCompany.App.UI.CrossPlatformApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarRentalCompany.App.UI.CrossPlatformApp
{
    public partial class App : Xamarin.Forms.Application
    {
        public static ApplicationService AppService { get; set; }

        public App()
        {
            InitializeComponent();

            AppService = new ApplicationService();
            MainPage = new NavigationPage(new SignInPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
