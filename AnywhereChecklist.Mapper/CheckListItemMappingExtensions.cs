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

        public static void UpdateFrom(this CheckListItem item, CheckListItemUpdate update)
        {
            item.Content = update.Content;
            item.IsCompleted = update.IsCompleted;
        }

    }
}
