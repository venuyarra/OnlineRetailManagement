using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailManagement.Models;
using System.Security.Claims;

namespace OnlineRetailManagement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (login.email == "admin@gmail.com" && login.password == "admin123")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, login.email),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal user = new ClaimsPrincipal(claimsidentity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        //ExpiresUtc= DateTime.UtcNow.AddMinutes(60),
                        AllowRefresh = true,
                    });
                    if (HttpContext.Request.Query["ReturnUrl"].ToString() != "")
                    {
                        return Redirect(HttpContext.Request.Query["ReturnUrl"]);

                    }

                    else
                        return RedirectToAction("Home", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid username and password");
            }
            ViewBag.Msg = "Invalid  credentials";
            return View();
        }
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Home","Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
