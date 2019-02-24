using AnywhereChecklist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AnywhereChecklist.Entities;

namespace AnywhereChecklist.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserControl userControl;
        private readonly SignInManager<User> signInManager;

        public AccountController(IUserControl userControl, 
                                    SignInManager<User> signInManager)
        {
            this.userControl = userControl;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp(string returnUrl) => View(new SignUp { ReturnUrl = returnUrl });

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            if (!ModelState.IsValid) return View(signUp);
            if (await userControl.SignUpAsync(signUp)) return Redirect("~/");
            else return this.ValidateAndView(signUp);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl) => View(new Login { ReturnUrl = returnUrl });

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid) return View(login);
            var user = await userControl.LoginCheckAsync(login);
            if (user == null) return this.ValidateAndView(login);
            await signInManager.SignInAsync(user, true);
            return Redirect("~/" + login.ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");
        }

    }
}
