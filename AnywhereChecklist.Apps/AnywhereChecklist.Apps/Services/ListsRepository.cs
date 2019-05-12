using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace AnywhereChecklist.Apps.Services
{
    public class ListsRepository
    {
        private readonly ApiClient apiClient;

        const string path = "mobileApi/lists";

        public ListsRepository(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IEnumerable<CheckList>> GetAsync()
        {
            var result = await apiClient.Client.GetAsync(path);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<CheckList>>(response);
            }
            else throw new Exception("error fetching data");
        }

        public async Task<CheckList> GetAsync(int id)
        {
            var result = await apiClient.Client.GetAsync($"{path}/{id}");
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CheckList>(response);
            }
            else throw new Exception("error fetching data");
        }

        public async Task<CheckList> AddAsync(CheckListAdd checkList)
        {
            var result = await apiClient.Client.PostAsJsonAsync(path, checkList);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CheckList>(response);
            }
            else throw new Exception("error adding data");
        }

        public async Task<CheckList> UpdateAsync(CheckListUpdate checkList)
        {
            var result = await apiClient.Client.PutAsJsonAsync(path, checkList);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CheckList>(response);
            }
            else throw new Exception("error updating data");
        }

        public async Task DeleteAsync(int id)
        {
            await apiClient.Client.DeleteAsync($"{path}/{id}");
        }

        

    }
}
