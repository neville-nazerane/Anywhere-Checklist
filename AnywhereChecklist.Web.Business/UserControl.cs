using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.Identity;
using NetCore.ModelValidation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Business
{
    class UserControl : IUserControl
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ModelValidator modelValidator;

        public const string UnknownErrorMessage = "An unknown error occured. Please try again";

        public UserControl(SignInManager<User> signInManager,
                           UserManager<User> userManager,
                           ModelValidator modelValidator)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.modelValidator = modelValidator;
        }

        public async Task<bool> SignUpAsync(SignUp signUp)
        {
            var user = new User { UserName = signUp.UserName };
            var result = await userManager.CreateAsync(user, signUp.Password);
            if (result.Succeeded) return true;
            if (result.Errors.Any())
                foreach (var err in result.Errors)
                    modelValidator.AddError(err.Description);
            else modelValidator.AddError(UnknownErrorMessage);
            return false;
        }

        public async Task<ClaimsPrincipal> LoginCheckAsync(Login login)
        {
            var user = userManager.Users.SingleOrDefault(u => u.UserName == login.UserName);
            if (user == null) modelValidator.AddError("Username doesn't exist");
            var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (result.Succeeded) return await signInManager.CreateUserPrincipalAsync(user);
            modelValidator.AddError("Invalid login");
            return null;
        }

    }
}
