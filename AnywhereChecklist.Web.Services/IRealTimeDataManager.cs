using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;

namespace AnywhereChecklist.Web.Services
{
    public interface IRealTimeDataManager
    {
        Task CheckListAddedAsync(Entities.CheckList checkList);

        Task CheckListDeletedAsync(int id);
        Task CheckListUpdatedAsync(CheckList result);
        Task CheckListItemAddedAsync(CheckListItem result);
        Task CheckListItemUpdatedAsync(CheckListItem result);
        Task CheckListItemDeletedAsync(int id);
    }
}
