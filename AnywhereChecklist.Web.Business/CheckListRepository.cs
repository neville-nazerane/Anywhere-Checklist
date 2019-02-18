using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using AnywhereChecklist.Web.Services;
using AnywhereChecklist.Web.Services.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Business
{
    class CheckListRepository : ICheckListRepository
    {
        private readonly ICheckListAccess access;
        private readonly IUserContext userContext;
        private readonly IRealTimeDataManager realTimeDataManager;

        public CheckListRepository(ICheckListAccess access,
                                   IUserContext userContext,
                                   IRealTimeDataManager realTimeDataManager)
        {
            this.access = access;
            this.userContext = userContext;
            this.realTimeDataManager = realTimeDataManager;
        }

        public async Task<CheckList> AddAsync(CheckListAdd add)
        {
            var response = await access.AddAsync(add, userContext.UserId);
            await realTimeDataManager.CheckListAddedAsync(response);
            return response;
        }

        public async Task<CheckList> Updatesync(CheckListUpdate update)
            => await access.UpdateAsync(update, userContext.UserId);

        public async Task<IEnumerable<CheckList>> GetAsync()
            => await access.GetAsync(userContext.UserId);

        public async Task<CheckList> GetAsync(int id)
            => await access.GetAsync(id, userContext.UserId);

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = await access.DeleteAsync(id, userContext.UserId);
            if (result) await realTimeDataManager.CheckListDeletedAsync(id);
            return result;
        }
    }
}
