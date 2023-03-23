using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailManagement.Models;
using System.Security.Claims;
using OnlineRetailManagement.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

namespace OnlineRetailManagement.Controllers
{
    public class AdminController : Controller
    {
        private IAdminRepository _adminRepository;
        

        public AdminController(IAdminRepository adminRepository) 
        {
            _adminRepository = adminRepository;
           
        }

        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            TempData["id"] = "";
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
        public IActionResult  AddUser()
        {
            ViewBag.Msg = "";
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                bool s = _adminRepository.GetUser(user);
                if (s)
                {
                    _adminRepository.AddUser(user);
                    return RedirectToAction("Home", "Home");
                }
               
                    ModelState.AddModelError(string.Empty,"This email is already taken. please register with new email");
                return View();
                

            }
            else
            {
                ViewBag.Msg = "Invalid Credentials";
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddProductId()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddProductId(Product product)
        {
            bool result = _adminRepository.AddProductId(product);
            if (!result)
            {
                ViewBag.Msg = "This product is already exists";
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }
        [HttpGet]
        public IActionResult UpdateProduct() 
        {
          
           
            return View();

        }
       
        [HttpGet]
        public  IActionResult UpdateProducts(string Email)
        {
            var res = _adminRepository.GetProductbyId(Convert.ToInt32(Email)); ;
            if(res==null)
            {
                TempData["id"]= "Id does not exist.";
                
                return RedirectToAction("UpdateProduct");
;
            }
            return View(res);
        }
        [HttpPost]
        public IActionResult UpdateProducts(int Id,Product product)
        {
           _adminRepository.UpdateProduct(product);
            return RedirectToAction("UpdateProduct", "Admin");
        }
        [HttpGet]
        public IActionResult DeleteProductId()
        {
           
            return View();

        }
        
        public IActionResult DeleteProduct(int Id)
        {
          bool t=  _adminRepository.DeleteProductId(Id);
            if(t)
            {
                return RedirectToAction("Home", "Home");

            }
            else
            {
                TempData["msg"] = "product with entered user id doesnt exist";
                
                return RedirectToAction("DeletePRoductId");
            }

        }
        public IActionResult GetAllOrders()
        {
            return View(_adminRepository.GetAllOrders());
        }
          
    }
}
