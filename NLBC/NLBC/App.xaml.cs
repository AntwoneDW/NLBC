using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NLBC.Services;
using NLBC.Views;

namespace NLBC
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
