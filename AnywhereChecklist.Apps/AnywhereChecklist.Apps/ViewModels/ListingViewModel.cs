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
    public class ListingViewModel : INotifyPropertyChanged
    {
        private readonly ListsRepository repository;
        private readonly UpdateSocket updateSocket;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CheckList> Lists { get; set; }

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
            await updateSocket.StartAsync();
            updateSocket.OnCheckListAdded(added => {
                Lists.Add(added);
            });
            updateSocket.OnCheckListUpdated(updated
                => Lists[Lists.IndexOf(Lists.SingleOrDefault(l => l.Id == updated.Id))] = updated);
            Lists = new ObservableCollection<CheckList>(await repository.GetAsync());
            _changed(nameof(Lists));
            updateSocket.OnCheckListDeleted(id => Lists.Remove(Lists.SingleOrDefault(l => l.Id == id)));
        }

        async Task _add()
        {
            try
            {
                await repository.AddAsync(NewList);
                NewList = new CheckListAdd();
                _changed(nameof(NewList));
            }
            catch { }
        }

        void _changed(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
