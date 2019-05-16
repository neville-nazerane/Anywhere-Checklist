using AnywhereChecklist.Apps.Services;
using AnywhereChecklist.Apps.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AnywhereChecklist.Apps.Services.Provider;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace AnywhereChecklist.Apps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListingPage : ContentPage
    {


        public ListingPage()
        {

            InitializeComponent();


            Appearing += ListingPage_Appearing;

            logout.Clicked += Logout_Clicked;

        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AuthPage());
        }

        private async void ListingPage_Appearing(object sender, EventArgs e)
        {
            if (await IsAuthenticatedAsync())
            {
                var vm = Get<ListingViewModel>();
                BindingContext = vm;
                await vm.InitAsync();
            }
            else await Navigation.PushModalAsync(new AuthPage());
        }

        protected override void OnDisappearing()
        {
            Appearing -= ListingPage_Appearing;
            logout.Clicked -= Logout_Clicked;
            base.OnDisappearing();
        }

    }
}