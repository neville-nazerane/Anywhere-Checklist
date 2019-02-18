using AnywhereChecklist.Entities;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AnywhereChecklist.Web.Helpers
{
    class UserContext : IUserContext
    {
        public int UserId => int.Parse(userManager.GetUserId(User));

        public string UserName => User.Identity.Name;

        ClaimsPrincipal User => httpContextAccessor.HttpContext.User;

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;

        public UserContext(IHttpContextAccessor httpContextAccessor,
                           UserManager<User> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

    }
}
