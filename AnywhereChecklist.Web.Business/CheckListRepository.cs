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

        public CheckListRepository(ICheckListAccess access, IUserContext userContext)
        {
            this.access = access;
            this.userContext = userContext;
        }

        public async Task<CheckList> Addsync(CheckListAdd add)
            => await access.AddAsync(add, userContext.UserId);

        public async Task<CheckList> Updatesync(CheckListUpdate update)
            => await access.UpdateAsync(update, userContext.UserId);

        public async Task<IEnumerable<CheckList>> GetAsync()
            => await access.GetAsync(userContext.UserId);

        public async Task<CheckList> GetAsync(int id)
            => await access.GetAsync(id, userContext.UserId);

        public async Task<bool> DeleteAsync(int id)
            => await access.DeleteAsync(id, userContext.UserId);


    }
}
