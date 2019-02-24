using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnywhereChecklist.Website.Hubs
{
    public class AuthHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            string key = Guid.NewGuid().ToString();
            Context.Items["key"] = key;
            await Groups.AddToGroupAsync(Context.ConnectionId, key);
        }

        public string FetchKey() => Context.Items["key"].ToString();



    }
}
