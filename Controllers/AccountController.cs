using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PFCWebApplication.Controllers
{
    public class AccountController : Controller
    {
        [Authorize] //blocks any anonymous access to this method
        public IActionResult Login()
        {
            //1. user will click on a link called Login with Google
            //2. it will try to access this action hence the url will be  Account/Login
            //3. The Authorize attribute will intercept the request, blocks anonymous access and
            //4. will redirect the user the Google Login page instead
            //5. Assuming, user will log in successfully, he is redirected back here

            return View();
        }

        public IActionResult Logout()
        {
            //deletes a cookie holding you logged in
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home"); //Home/Index
        }
    }
}
