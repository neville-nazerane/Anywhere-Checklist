using AnywhereChecklist.Constants;
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
                                                IConfiguration configuration)
            => services
                    .AddScoped<ICheckListAccess, CheckListAccess>()
                    .AddScoped<ICheckListAccess, CheckListAccess>()
                    .AddDbContext<AppDbContext>(config =>
                        config.UseSqlServer(configuration.GetConnectionString(DB.ConnectionKey)));



    }
}
