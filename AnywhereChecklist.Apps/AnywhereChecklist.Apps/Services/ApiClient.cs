using NetCore.Apis.Consumer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AnywhereChecklist.Apps.Services
{
    public class ApiClient
    {

        public HttpClient Client { get; }
        public ApiConsumer Consumer { get; }

        const string JwtKey = "authJwt";

        public ApiClient()
        {
            Client = new HttpClient {
                BaseAddress = new Uri(Constants.baseUrl)
            };
            Consumer = new ApiConsumer(Client) {
                ApiVersion = ApiVersion.Version_2_2
            };
        }

        public async Task SetJwtAsync(string token)
        {
            await SecureStorage.SetAsync(JwtKey, token);
            SetAuthHeader(token);
        }

        void SetAuthHeader(string token)
        {
            Consumer.BearerToken = token;
        }

        public static async Task<string> GetJwtAsync() => await SecureStorage.GetAsync(JwtKey);

        public async Task<bool> IsAuthenticatedAsync()
        {
            var header = Client.DefaultRequestHeaders.Authorization;
            if (header?.Scheme == "bearer") return true;
            else
            {
                string token = await GetJwtAsync();
                if (token == null) return false;
                SetAuthHeader(token);
                return true;
            }
        }

        public void UnAuthenticate()
        {
            SecureStorage.Remove(JwtKey);
            Client.DefaultRequestHeaders.Authorization = null;
        }

    }
}
