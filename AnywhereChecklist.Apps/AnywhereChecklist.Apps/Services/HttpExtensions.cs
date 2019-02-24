using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Apps.Services
{
    public static class HttpExtensions
    {

        public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client,
                                        string path, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(path, content);
        }
        
        public static async Task<HttpResponseMessage> PutAsJsonAsync(this HttpClient client,
                                        string path, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PutAsync(path, content);
        }

    }
}
