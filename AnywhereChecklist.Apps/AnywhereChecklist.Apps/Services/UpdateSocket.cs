using AnywhereChecklist.Entities;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AnywhereChecklist.Apps.Services.Constants;


namespace AnywhereChecklist.Apps.Services
{
    public class UpdateSocket
    {

        private readonly HubConnection connection;

        public UpdateSocket(ApiClient apiClient)
        {
            connection = new HubConnectionBuilder()
                                .WithUrl(socketUrl + "/dataUpdates", o => {
                                    //o.AccessTokenProvider = () => Task.FromResult(apiClient.UserToken);
                                    o.Headers.Add("Authorization", "bearer " + apiClient.UserToken);
                                })
                                .Build();
        }

        public async Task StartAsync() => await connection.StartAsync();

        public void OnCheckListAdded(Action<CheckList> handler)
            => connection.On("checkListAdded", handler);

        public void OnCheckListUpdated(Action<CheckList> handler)
            => connection.On("checkListUpdated", handler);

        public void OnCheckListDeleted(Action<int> handler)
            => connection.On("checkListDeleted", handler);

        public void OnCheckListItemAdded(Action<CheckListItem> handler)
            => connection.On("checkListItemAdded", handler);

        public void OnCheckListItemDeleted(Action<int> handler)
            => connection.On("checkListItemDeleted", handler);

        public void OnCheckListItemUpdated(Action<CheckListItem> handler)
            => connection.On("checkListItemUpdated", handler);

    }
}
