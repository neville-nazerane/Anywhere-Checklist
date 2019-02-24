using AnywhereChecklist.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NetCore.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnywhereChecklist.Website.Hubs
{
    public class SocketAuthMiddleware
    {
        private readonly RequestDelegate next;

        public SocketAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
                                      SignInManager<User> signInManager)
        {
            if (!context.Request.Path.Value.Contains("api", StringComparison.CurrentCultureIgnoreCase))
            {
                var result = await context.AuthenticateAsync(NetCoreJwtDefaults.SchemeName);
                if (result.Succeeded)
                {
                    var user = await signInManager.UserManager.GetUserAsync(result.Principal);
                    await signInManager.SignInAsync(user, false);
                }
            }
            await next(context);
        }

    }
}
