using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Services
{
    public interface ICheckListItemRepository
    {
        Task<CheckListItem> AddAsync(CheckListItemAdd item);

        Task<CheckListItem> CheckAsync(int id, bool check = true);

        Task<bool> DeleteAcync(int id);

        Task<CheckListItem> GetAync(int id);

        Task<IEnumerable<CheckListItem>> GetForListAcync(int listId);

        Task<CheckListItem> UdpateAsync(CheckListItemUpdate item);

    }
}
