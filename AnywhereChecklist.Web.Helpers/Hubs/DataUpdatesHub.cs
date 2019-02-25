using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using NetCore.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnywhereChecklist.Web.Helpers.Hubs
{

    [Authorize(AuthenticationSchemes = "Identity.Application," + NetCoreJwtDefaults.SchemeName)]
    class DataUpdatesHub : Hub
    {
    }
}
