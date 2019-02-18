using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Entities;

namespace AnywhereChecklist.Website.Models
{
    public class CheckListViewModel
    {

        public IEnumerable<CheckList> CheckLists { get; set; }

        public CheckList CheckList { get; set; }

        public IEnumerable<CheckListItem> Items { get; set; }



    }
}
