using AnywhereChecklist.Apps.Services;
using AnywhereChecklist.Entities;
using AnywhereChecklist.Mapper;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnywhereChecklist.Apps.ViewModels
{
    public class CheckListDisplay : ViewModelBase
    {
        private readonly ListsRepository repository;
        private bool isEditing;
        private CheckList checkList;
        private CheckListUpdate update;

        public int Id => checkList.Id;

        public CheckList CheckList
        {
            get => checkList;
            set
            {
                checkList = value;
                Update = value.ToUpdate();
                OnPropertyChanged();
            }
        }

        public CheckListUpdate Update
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
        public bool NotEditing => !IsEditing;

        #region commands

        public Command StartEditing { get; private set; }
        public Command StopEditing { get; private set; }
        public Command SaveEdit { get; private set; }
        public Command Delete { get; private set; }

        #endregion

        public CheckListDisplay(ListsRepository repository)
        {
            StartEditing = new Command(_startEditing);
            StopEditing = new Command(_stopEditing);
            SaveEdit = new Command(async () => await _saveEdit());
            Delete = new Command(async () => await _delete());
            this.repository = repository;
        }

        void _startEditing()
        {
            Update.Title = CheckList.Title;
            IsEditing = true;
        }

        void _stopEditing() => IsEditing = false;

        async Task _saveEdit()
        {
            await repository.UpdateAsync(Update);
            IsEditing = false;
        }

        async Task _delete() => await repository.DeleteAsync(CheckList.Id);

    }

}
