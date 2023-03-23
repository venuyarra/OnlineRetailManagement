using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailManagement.Models;
using OnlineRetailManagement.Repository;
using System.Security.Claims;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace OnlineRetailManagement.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
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
                User k = _userRepository.GetUser(login);
                if (k != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, login.email),
                        new Claim(ClaimTypes.Role, "User"),
                        new Claim(ClaimTypes.Name,k.name)
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
            return RedirectToAction("Home", "Home");
        }

        public IActionResult DisplayAllProductsByName(string productname)
        {

            return View(_userRepository.GetAllProductsByName(productname));
        }
        public IActionResult Description(int id)
        {
       
            return View(_userRepository.GetProduct(id));
        }
        public IActionResult GetAllProducts()
        {
            return View(_userRepository.GetAllProducts());
        }
        [HttpGet]
        [Authorize]
        public IActionResult Search()
        {
            return View();
        }
       



    }
}
