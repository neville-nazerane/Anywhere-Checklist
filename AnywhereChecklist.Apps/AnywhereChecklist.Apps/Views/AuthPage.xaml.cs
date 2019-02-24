using AnywhereChecklist.Apps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AnywhereChecklist.Apps.Services.Provider;

namespace AnywhereChecklist.Apps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();

            Appearing += AuthPage_Appearing;

        }

        private async void AuthPage_Appearing(object sender, EventArgs e)
        {
            if (IsAuthenticated())
                await Navigation.PushModalAsync(new ListingPage());
            else
            {
                var socket = Get<AuthSocket>();
                socket.OnAuthenticated += Socket_OnAuthenticated;
                await socket.StartAsync();
                Device.OpenUri(new Uri(socket.LoginPath));
            }
        }

        private async void Socket_OnAuthenticated(object sender, EventArgs e) 
            => await Navigation.PopModalAsync();

    }
}