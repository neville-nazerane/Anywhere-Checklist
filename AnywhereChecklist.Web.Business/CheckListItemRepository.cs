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

        public CheckListItemRepository(ICheckListItemAccess access, IUserContext userContext)
        {
            this.access = access;
            this.userContext = userContext;
        }

        public async Task<CheckListItem> AddAsync(CheckListItemAdd item)
            => await access.AddAsync(item, userContext.UserId);

        public async Task<CheckListItem> UdpateAsync(CheckListItemUpdate item)
            => await access.UpdateAsync(item, userContext.UserId);

        public async Task<CheckListItem> CheckAsync(int id, bool check = true)
            => await access.CheckAcync(id, check, userContext.UserId);

        public async Task<CheckListItem> GetAync(int id)
            => await access.GetAsync(id, userContext.UserId);

        public async Task<IEnumerable<CheckListItem>> GetForListAcync(int listId)
            => await access.GetForListAsync(listId, userContext.UserId);

        public async Task<bool> DeleteAcync(int id)
            => await access.DeleteAsync(id, userContext.UserId);

    }
}
