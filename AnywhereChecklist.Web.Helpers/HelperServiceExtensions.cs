using AnywhereChecklist.Web.Helpers;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HelperServiceExtensions
    {

        public static IServiceCollection AddHelpers(this IServiceCollection services)
            => services
                    .AddScoped<IRealTimeDataManager, RealTimeDataManager>()
                    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                    .AddScoped<IUserContext, UserContext>();



    }
}
