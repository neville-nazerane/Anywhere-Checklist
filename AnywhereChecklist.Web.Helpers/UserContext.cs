using AnywhereChecklist.Entities;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NetCore.Jwt;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AnywhereChecklist.Web.Helpers
{
    class UserContext : IUserContext
    {
        public int UserId => int.Parse(userManager.GetUserId(User));

        public string TokenPlease => User.Identity.IsAuthenticated ?  bearerManager.Generate(User.Claims) : null;

        public string UserName => User.Identity.Name;

        ClaimsPrincipal User => httpContextAccessor.HttpContext.User;

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        private readonly IBearerManager bearerManager;

        public UserContext(IHttpContextAccessor httpContextAccessor,
                           UserManager<User> userManager,
                           IBearerManager bearerManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.bearerManager = bearerManager;
        }

    }
}
