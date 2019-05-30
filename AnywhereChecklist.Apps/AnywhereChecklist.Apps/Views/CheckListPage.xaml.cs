using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AnywhereChecklist.Apps.Services.Provider;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnywhereChecklist.Apps.ViewModels;

namespace AnywhereChecklist.Apps.Views
{

    [QueryProperty(nameof(CheckListIdQuery), "id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckListPage : ContentPage
    {

        public string CheckListIdQuery
        {
            set
            {
                CheckListId = int.Parse(value);
            }
        }

        public int CheckListId { get; set; }

        public CheckListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (await IsAuthenticatedAsync())
            {
                var vm = Get<CheckListViewModel>();
                BindingContext = vm;
                await vm.InitAsync(CheckListId);
            }
            else await Navigation.PushModalAsync(new AuthPage());
        }

    }
}