using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Apps.Services
{
    public class ItemsRepository
    {
        private readonly ApiClient apiClient;

        const string path = "mobileApi/items";

        public ItemsRepository(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<CheckListItem> GetAsync(int id)
            => await apiClient.Consumer.GetAsync<CheckListItem>(id.ToString());

        public async Task<IEnumerable<CheckListItem>> GetForListAsync(int listId)
            => (await apiClient.Consumer.GetAsync<IEnumerable<CheckListItem>>($"list/{listId}")).Data;

        public async Task<CheckListItem> UpdateAsync(CheckListItemUpdate checkList)
            => await apiClient.Consumer.PutAsync<CheckListItem>(string.Empty, checkList);

        public async Task ToggleAsync(int id)
            => await apiClient.Consumer.PutAsync($"toggle/{id}", null);

        public async Task<CheckListItem> DeleteAsync(int id)
            => await apiClient.Consumer.DeleteAsync<CheckListItem>(id.ToString());

    }
}
