using AnywhereChecklist.Apps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnywhereChecklist.Apps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("home", typeof(ListingPage));
            Routing.RegisterRoute("login", typeof(AuthPage));
            Routing.RegisterRoute("item", typeof(CheckListPage));
        }

    }
}