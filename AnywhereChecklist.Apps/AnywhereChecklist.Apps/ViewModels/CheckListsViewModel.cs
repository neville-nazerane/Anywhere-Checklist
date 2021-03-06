﻿using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AnywhereChecklist.Apps.Services;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AnywhereChecklist.Apps.ViewModels
{
    public class CheckListsViewModel : ViewModelBase
    {
        private readonly ListsRepository repository;
        private bool isEditing;
        private CheckList checkList;
        private CheckListUpdate update;

        public CheckList CheckList
        {
            get => checkList;
            set
            {
                checkList = value;
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

        public bool NotEditing => !IsEditing;

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

        #region commands

        public Command StartEditing { get; private set; }
        public Command StopEditing { get; private set; }
        public Command SaveEdit { get; private set; }
        public Command Delete { get; private set; }

        #endregion

        public CheckListsViewModel(ListsRepository repository)
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
