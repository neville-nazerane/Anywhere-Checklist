using AnywhereChecklist.Website.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Jwt;

namespace AnywhereChecklist.Website.Controllers
{

    public class MobileAuthController : Controller
    {
        private readonly IHubContext<AuthHub> authHub;
        private readonly IBearerManager bearerManager;

        public MobileAuthController(IHubContext<AuthHub> authHub, IBearerManager bearerManager)
        {
            this.authHub = authHub;
            this.bearerManager = bearerManager;
        }

        [Authorize]
        public async Task<string> LoginFor(string id)
        {
            string token = bearerManager.Generate(User.Claims);
            await authHub.Clients.Group(id).SendAsync("authorized", token);
            return "Done! Please go back to the app now";
        }

    }
}
