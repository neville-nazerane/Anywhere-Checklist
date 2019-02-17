using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Services.Access
{
    public interface ICheckListAccess
    {

        Task<CheckList> AddAsync(CheckListAdd add, int userId);

        Task<bool> DeleteAsync(int id, int userId);

        Task<bool> ExistsAsync(int id, int userId);

        Task<IEnumerable<CheckList>> GetAsync(int userId);

        Task<CheckList> GetAsync(int id, int userId);

        Task<CheckList> UpdateAsync(CheckListUpdate update, int userId);
    }
}
