using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using AnywhereChecklist.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AnywhereChecklist.Apps.Services;
using System.Threading.Tasks;

namespace AnywhereChecklist.Apps.ViewModels
{
    class CheckItemDisplay : ViewModelBase
    {
        private bool isEditing;
        private CheckListItem item;
        private CheckListItemUpdate update;
        private readonly ItemsRepository itemsRepository;

        public CheckListItem Item
        {
            get => item;
            set
            {
                item = value;
                OnPropertyChanged();
                Update = item.ToUpdate();
            }
        }

        public CheckListItemUpdate Update
        {
            get => update;
            set
            {
                update = value;
                OnPropertyChanged();
            }
        }

        public bool IsEditing
        {
            get => isEditing;
            set
            {
                isEditing = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NotEditing));
            }
        }

        public bool NotEditing => !isEditing;

        public Command StartUpdateCMD { get; set; }
        public Command CancelUpdateCMD { get; set; }
        public Command UpdateCMD { get; set; }

        public CheckItemDisplay(ItemsRepository itemsRepository)
        {
            StartUpdateCMD = new Command(StartUpdate);
            CancelUpdateCMD = new Command(CancelUpdate);
            UpdateCMD = new Command(async () => await UpdateAsync());
            this.itemsRepository = itemsRepository;
        }

        private void StartUpdate()
        {
            isEditing = false;
        }

        private void CancelUpdate()
        {
            isEditing = false;
        }

        public async Task UpdateAsync()
        {
            await itemsRepository.UpdateAsync(Update);
            Item = Update.ToCheckListItem();
            isEditing = false;
        }

    }
}
