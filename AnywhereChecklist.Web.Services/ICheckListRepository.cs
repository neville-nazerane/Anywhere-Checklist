
using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AnywhereChecklist.Web.Services
{
    public interface ICheckListRepository
    {
        Task<CheckList> AddAsync(CheckListAdd add);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<CheckList>> GetAsync();

        Task<CheckList> GetAsync(int id);

        Task<CheckList> Updatesync(CheckListUpdate update);

    }
}
