using AnywhereChecklist.Apps.Services;
using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnywhereChecklist.Apps.ViewModels
{
    public class ListingViewModel : ViewModelBase
    {
        private readonly ListsRepository repository;
        private readonly UpdateSocket updateSocket;

        public ObservableCollection<CheckListDisplay> Lists { get; set; }

        public CheckListAdd NewList { get; set; }

        public Command Add { get; }

        public ListingViewModel(ListsRepository repository, UpdateSocket updateSocket)
        {
            this.repository = repository;
            this.updateSocket = updateSocket;
            NewList = new CheckListAdd();
            Add = new Command(async () => await _add());
        }

        public async Task InitAsync()
        {
            if (!updateSocket.IsStarted)
            {
                await updateSocket.StartAsync();
                updateSocket.OnCheckListAdded(added => {
                    Lists.Add(_makeDisplay(added));
                });
                updateSocket.OnCheckListUpdated(updated
                    => Lists[Lists.IndexOf(Lists.SingleOrDefault(l => l.Id == updated.Id))] = _makeDisplay(updated));
                updateSocket.OnCheckListDeleted(id => Lists.Remove(Lists.SingleOrDefault(l => l.Id == id)));
            }
            Lists = new ObservableCollection<CheckListDisplay>((await repository.GetAsync()).Select(c => _makeDisplay(c)));
            OnPropertyChanged(nameof(Lists));
        }

        async Task _add()
        {
            try
            {
                await repository.AddAsync(NewList);
                NewList = new CheckListAdd();
                OnPropertyChanged(nameof(NewList));
            }
            catch { }
        }

        CheckListDisplay _makeDisplay(CheckList checkList)
            => new CheckListDisplay(repository) { CheckList = checkList };


    }
}
