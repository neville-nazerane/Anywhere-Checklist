using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnywhereChecklist.Apps.Services
{
    public class PageHandler
    {

        public INavigation Navigation => CurrentPage.Navigation;

        public Page CurrentPage { get; set; }

        public async Task NavigateAsync(Page page)
        {
            await Navigation.PushModalAsync(page);
            CurrentPage = page;
        }

    }
}
