using AnywhereChecklist.Entities;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnywhereChecklist.Web.Data
{
    public abstract class AbstractDbContext : IdentityDbContext<User, UserRole, int>
    {

        public AbstractDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CheckList> CheckLists { get; set; }

        public DbSet<CheckListItem> CheckListItems { get; set; }

    }
}
