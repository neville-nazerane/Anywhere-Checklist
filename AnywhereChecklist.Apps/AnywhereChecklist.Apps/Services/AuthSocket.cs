using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static AnywhereChecklist.Apps.Services.Constants;

namespace AnywhereChecklist.Apps.Services
{
    class AuthSocket
    {
        private readonly HubConnection connection;
        private readonly ApiClient apiClient;

        public string LoginPath { get; private set; }

        public event EventHandler OnAuthenticated;

        public AuthSocket(ApiClient apiClient)
        {
            connection = new HubConnectionBuilder()
                                .WithUrl(socketUrl + "/authHub")
                                .Build();

            connection.On<string>("authorized", Authenticate);

            this.apiClient = apiClient;
        }

        void Authenticate(string token)
        {
            apiClient.UserToken = token;
            apiClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            OnAuthenticated(this, EventArgs.Empty);
        }

        public async Task StartAsync()
        {
            await connection.StartAsync();
            string key = await connection.InvokeAsync<string>("fetchKey");
            LoginPath = $"{baseUrl}/MobileAuth/loginFor/{key}";
        }

    }
}
