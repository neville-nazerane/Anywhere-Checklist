using AnywhereChecklist.Constants;
using AnywhereChecklist.Entities;
using AnywhereChecklist.Web.DataAccess;
using AnywhereChecklist.Web.Services.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AccessServiceExtensions
    {

        public static IServiceCollection AddAccess(this IServiceCollection services,
                                                IConfiguration configuration, bool requireIdentity = true)
        {

            if (requireIdentity)
                services.AddIdentity<User, UserRole>()
                        .AddEntityFrameworkStores<AppDbContext>();

            return services
                               .AddScoped<ICheckListAccess, CheckListAccess>()
                               .AddScoped<ICheckListItemAccess, CheckListItemAccess>()
                               .AddDbContext<AppDbContext>(config =>
                                   config.UseSqlServer(configuration.GetConnectionString(DB.ConnectionKey)));
        }
    }
}
