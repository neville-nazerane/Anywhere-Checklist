using AnywhereChecklist.Apps.Services;
using AnywhereChecklist.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Apps.ViewModels
{
    public class CheckListViewModel : ViewModelBase
    {
        private readonly ItemsRepository repository;
        private ObservableCollection<CheckItemDisplay> items;

        public ObservableCollection<CheckItemDisplay> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public CheckListViewModel(ItemsRepository repository)
        {
            this.repository = repository;
        }

        public async Task InitAsync(int listId)
        {
            var data = await repository.GetForListAsync(listId);
            Items = new ObservableCollection<CheckItemDisplay>(data.Select(d => MakeDisplay(d)));
        }

        private CheckItemDisplay MakeDisplay(CheckListItem item)
            => new CheckItemDisplay(repository) { Item = item };

    }
}
