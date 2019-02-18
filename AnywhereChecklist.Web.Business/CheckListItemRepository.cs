using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using AnywhereChecklist.Web.Services;
using AnywhereChecklist.Web.Services.Access;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Business
{
    class CheckListItemRepository : ICheckListItemRepository
    {
        private readonly ICheckListItemAccess access;
        private readonly IUserContext userContext;
        private readonly IRealTimeDataManager realTimeDataManager;

        public CheckListItemRepository(ICheckListItemAccess access,
                                       IUserContext userContext,
                                       IRealTimeDataManager realTimeDataManager)
        {
            this.access = access;
            this.userContext = userContext;
            this.realTimeDataManager = realTimeDataManager;
        }

        public async Task<CheckListItem> AddAsync(CheckListItemAdd item)
        {
            var result = await access.AddAsync(item, userContext.UserId);
            if (result != null) await realTimeDataManager.CheckListItemAddedAsync(result);
            return result;
        }

        public async Task<CheckListItem> UdpateAsync(CheckListItemUpdate item)
        {
            var result = await access.UpdateAsync(item, userContext.UserId);
            if (result != null) await realTimeDataManager.CheckListItemUpdatedAsync(result);
            return result;
        }

        public async Task<CheckListItem> CheckAsync(int id, bool check = true)
        {
            var result = await access.CheckAsync(id, check, userContext.UserId);
            if (result != null) await realTimeDataManager.CheckListItemUpdatedAsync(result);
            return result;
        }

        public async Task<CheckListItem> GetAync(int id)
            => await access.GetAsync(id, userContext.UserId);

        public async Task<IEnumerable<CheckListItem>> GetForListAcync(int listId)
            => await access.GetForListAsync(listId, userContext.UserId);

        public async Task<bool> DeleteAsync(int id)
        {
            var success = await access.DeleteAsync(id, userContext.UserId);
            if (success) await realTimeDataManager.CheckListItemDeletedAsync(id);
            return success;
        }

        public async Task ToggleAsync(int id)
        {
            var result = await access.ToggleAsync(id, userContext.UserId);
            if (result != null) await realTimeDataManager.CheckListItemUpdatedAsync(result);
        }
    }
}
