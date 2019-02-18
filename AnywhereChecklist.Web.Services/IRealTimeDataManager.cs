using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Services
{
    public interface IRealTimeDataManager
    {
        Task CheckListAddedAsync(Entities.CheckList checkList);

        Task CheckListDeletedAsync(int id);
    }
}
