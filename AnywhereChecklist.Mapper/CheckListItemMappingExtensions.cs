using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnywhereChecklist.Mapper
{
    public static class CheckListItemMappingExtensions
    {

        public static CheckListItem ToCheckListItem(this CheckListItemAdd add)
            => new CheckListItem {
                Content = add.Content,
                IsCompleted = add.IsCompleted,
                CheckListId = add.CheckListId
            };

        public static CheckListItem ToCheckListItem(this CheckListItemUpdate update)
            => new CheckListItem
            {
                Id = update.Id,
                Content = update.Content,
                IsCompleted = update.IsCompleted
            };

        public static CheckListItemUpdate ToUpdate(this CheckListItem item)
            => new CheckListItemUpdate {
                Id = item.Id,
                Content = item.Content,
                IsCompleted = item.IsCompleted
            };

        public static void UpdateFrom(this CheckListItem item, CheckListItemUpdate update)
        {
            item.Content = update.Content;
            item.IsCompleted = update.IsCompleted;
        }

    }
}
