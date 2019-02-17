using AnywhereChecklist.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Web.Services
{
    public interface IUserControl
    {
        Task<ClaimsPrincipal> LoginCheckAsync(Login login);
        Task<bool> SignUpAsync(SignUp signUp);


    }
}
