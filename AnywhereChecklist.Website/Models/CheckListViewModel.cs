using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Entities;

namespace AnywhereChecklist.Website.Models
{
    public class CheckListViewModel
    {

        public int? CheckListId { get; set; }

        public IEnumerable<CheckList> CheckLists { get; set; }

        public CheckList CheckList { get; set; }

        public IEnumerable<CheckListItem> Items { get; set; }

        public CheckListItem Item { get; set; }

    }
}
