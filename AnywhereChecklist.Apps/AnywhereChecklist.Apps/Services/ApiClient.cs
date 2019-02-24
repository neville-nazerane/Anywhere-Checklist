using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AnywhereChecklist.Apps.Services
{
    public class ApiClient
    {

        public string UserToken { get; set; }

        public HttpClient Client { get; }

        public ApiClient()
        {
            Client = new HttpClient {
                BaseAddress = new Uri(Constants.baseUrl)
            };   
        }

        public bool IsAuthenticated()
        {
            var header = Client.DefaultRequestHeaders.Authorization;
            return header?.Scheme == "bearer";
        }

        public void UnAuthenticate()
        {
            Client.DefaultRequestHeaders.Authorization = null;
        }

    }
}
