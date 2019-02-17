using AnywhereChecklist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.Authentication;

namespace AnywhereChecklist.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserControl userControl;

        public AccountController(IUserControl userControl)
        {
            this.userControl = userControl;
        }

        public IActionResult SignUp(string returnUrl) => View(new SignUp { ReturnUrl = returnUrl });

        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            if (!ModelState.IsValid) return View(signUp);
            if (await userControl.SignUpAsync(signUp)) return Redirect("~/");
            else return this.ValidateAndView(signUp);
        }

        public IActionResult Login(string returnUrl) => View(new Login { ReturnUrl = returnUrl });

        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid) return View(login);
            var principle = await userControl.LoginCheckAsync(login);
            if (principle == null) return this.ValidateAndView(login);
            await HttpContext.SignInAsync(principle);
            return Redirect("~/");
        }

    }
}
