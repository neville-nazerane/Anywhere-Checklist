using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Services.Access
{
    public interface ICheckListItemAccess
    {

        Task<CheckListItem> AddAsync(CheckListItemAdd add, int userId);

        Task<bool> DeleteAsync(int id, int userId);

        Task<CheckListItem> GetAsync(int id, int userId);

        Task<IEnumerable<CheckListItem>> GetForListAsync(int listId, int userId);

        Task<CheckListItem> UpdateAsync(CheckListItemUpdate update, int userId);
        Task<CheckListItem> CheckAcync(int id, bool check, int userId);
    }
}
