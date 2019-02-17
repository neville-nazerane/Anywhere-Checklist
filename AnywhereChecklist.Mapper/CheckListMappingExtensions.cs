using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnywhereChecklist.Mapper
{
    public static class CheckListMappingExtensions
    {

        public static CheckList ToCheckList(this CheckListAdd add)
            => new CheckList {
                    Title = add.Title
                };

        public static void UpdateFrom(this CheckList checkList, CheckListUpdate update)
        {
            checkList.Title = update.Title;
        }

    }
}
