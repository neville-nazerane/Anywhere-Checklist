using AnywhereChecklist.Apps.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnywhereChecklist.Apps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListingPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
