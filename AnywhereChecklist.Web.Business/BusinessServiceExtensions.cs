using AnywhereChecklist.Web.Business;
using AnywhereChecklist.Web.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessServiceExtensions
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services)
            => services
                    .AddNetCoreValidations()
                    .AddScoped<IUserControl, UserControl>()
                    .AddScoped<ICheckListItemRepository, CheckListItemRepository>()
                    .AddScoped<ICheckListRepository, CheckListRepository>();

    }
}
