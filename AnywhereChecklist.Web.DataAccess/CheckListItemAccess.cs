using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using AnywhereChecklist.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnywhereChecklist.Web.Services.Access;

namespace AnywhereChecklist.Web.DataAccess
{
    class CheckListItemAccess : ICheckListItemAccess
    {
        private readonly AppDbContext context;

        public CheckListItemAccess(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<CheckListItem> AddAsync(CheckListItemAdd add, int userId)
        {
            if (!await context.CheckLists.AnyAsync(c => c.Id == add.CheckListId && c.UserId == userId))
                return null;
            var toAdd = add.ToCheckListItem();
            toAdd.CreatedOn = DateTime.Now;
            await context.AddAsync(toAdd);
            await context.SaveChangesAsync();
            return toAdd;
        }

        public async Task<CheckListItem> UpdateAsync(CheckListItemUpdate update, int userId)
        {
            var toUpdate = await context.CheckListItems.SingleOrDefaultAsync(c => c.Id == update.Id 
                                                        && c.CheckList.UserId == userId);
            if (toUpdate != null)
            {
                toUpdate.UpdateFrom(update);
                toUpdate.UpdatedOn = DateTime.Now;
                await context.SaveChangesAsync();
            }
            return toUpdate;
        }

        public async Task<IEnumerable<CheckListItem>> GetForListAsync(int listId, int userId)
            => await context.CheckListItems.AsNoTracking().Where(c => c.CheckListId == listId
                                && c.CheckList.UserId == userId).ToArrayAsync();

        public async Task<CheckListItem> GetAsync(int id, int userId)
            => await context.CheckListItems.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id
                                            && c.CheckList.UserId == userId);

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var toDelete = await context.CheckListItems.SingleOrDefaultAsync(c => c.Id == id
                                                        && c.CheckList.UserId == userId);
            if (toDelete == null) return false;
            context.Remove(toDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<CheckListItem> CheckAsync(int id, bool check, int userId)
        {
            var item = await context.CheckListItems.SingleOrDefaultAsync(c => c.Id == id
                                            && c.CheckList.UserId == userId);
            if (item != null)
            {
                item.IsCompleted = check;
                await context.SaveChangesAsync();
                return item;
            }
            else return null;
        }

        public async Task<CheckListItem> ToggleAsync(int id, int userId)
        {
            var item = await context.CheckListItems.SingleOrDefaultAsync(c => c.Id == id
                                            && c.CheckList.UserId == userId);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                await context.SaveChangesAsync();
                return item;
            }
            else return null;
        }
    }
}
