using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Essentials;
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

            connection.On<string>("authorized", async (token) => await AuthenticateAsync(token));

            this.apiClient = apiClient;
        }

        async Task AuthenticateAsync(string token)
        {
            await apiClient.SetJwtAsync(token);
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
