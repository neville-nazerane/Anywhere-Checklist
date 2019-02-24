
using AnywhereChecklist.Web.Helpers.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Builder
{
    public static class HelperMiddleWareExtensions
    {

        public static IApplicationBuilder UseHelpers(this IApplicationBuilder app)
          =>   app.UseSignalR(c => c.MapHub<DataUpdatesHub>("/dataUpdates"));

        public static void MapHelpers(this HubRouteBuilder builder)
            => builder.MapHub<DataUpdatesHub>("/dataUpdates");

    }
}
