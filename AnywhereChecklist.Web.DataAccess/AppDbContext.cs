using AnywhereChecklist.Entities;
using AnywhereChecklist.Web.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnywhereChecklist.Web.DataAccess
{
    class AppDbContext : AbstractDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }



    }
}
