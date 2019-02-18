using AnywhereChecklist.Entities;
using AnywhereChecklist.Web.Helpers.Hubs;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Helpers
{
    class RealTimeDataManager : IRealTimeDataManager
    {
        private readonly IHubContext<DataUpdatesHub> hubContext;
        private readonly IUserContext userContext;

        IClientProxy User => hubContext.Clients.User(userContext.UserId.ToString());

        public RealTimeDataManager(IHubContext<DataUpdatesHub> hubContext,
                                   IUserContext userContext)
        {
            this.hubContext = hubContext;
            this.userContext = userContext;
        }

        public async Task CheckListAddedAsync(CheckList checkList) 
            => await User.SendAsync("checkListAdded", checkList);

        public async Task CheckListDeletedAsync(int id)
            => await User.SendAsync("checkListDeleted", id);

        public async Task CheckListUpdatedAsync(CheckList result)
            => await User.SendAsync("checkListUpdated", result);

        public async Task CheckListItemAddedAsync(CheckListItem result)
            => await User.SendAsync("checkListItemAdded", result);

        public async Task CheckListItemUpdatedAsync(CheckListItem result)
            => await User.SendAsync("checkListItemUpdated", result);

        public async Task CheckListItemDeletedAsync(int id)
            => await User.SendAsync("checkListItemDeleted", id);

    }
}
