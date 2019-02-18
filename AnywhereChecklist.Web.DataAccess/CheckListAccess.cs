using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using AnywhereChecklist.Mapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnywhereChecklist.Web.Services.Access;

namespace AnywhereChecklist.Web.DataAccess
{
    class CheckListAccess : ICheckListAccess
    {
        private readonly AppDbContext context;

        public CheckListAccess(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<CheckList> AddAsync(CheckListAdd add, int userId)
        {
            var toAdd = add.ToCheckList();
            toAdd.CreatedOn = DateTime.Now;
            toAdd.UserId = userId;
            await context.AddAsync(toAdd);
            await context.SaveChangesAsync();
            return toAdd;
        }

        public async Task<CheckList> UpdateAsync(CheckListUpdate update, int userId)
        {
            var toUpdate = await context.CheckLists.SingleOrDefaultAsync(c => c.Id == update.Id && c.UserId == userId);
            if (toUpdate != null)
            {
                toUpdate.UpdateFrom(update);
                toUpdate.UpdatedOn = DateTime.Now;
                await context.SaveChangesAsync();
            }
            return toUpdate;
        }

        public async Task<IEnumerable<CheckList>> GetAsync(int userId)
            => await context.CheckLists.AsNoTracking().Where(c => c.UserId == userId).ToArrayAsync();

        public async Task<CheckList> GetAsync(int id, int userId)
            => await context.CheckLists.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id && c.UserId == userId);

        public async Task<bool> ExistsAsync(int id, int userId)
            => await context.CheckLists.AsNoTracking().AnyAsync(c => c.Id == id && c.UserId == userId);

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var toDelete = await context.CheckLists.SingleOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (toDelete == null) return false;
            context.Remove(toDelete);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
