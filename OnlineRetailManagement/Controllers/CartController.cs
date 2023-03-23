using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailManagement.Repository;

namespace OnlineRetailManagement.Controllers
{
    public class CartController : Controller
    {
        private IUserRepository _userRepository;

        public CartController(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

       
        public IActionResult AddtoCart(int Id)
        {
            
            var useremail = HttpContext.User.Claims.ToList()[0].Value;
          _userRepository.AddProducttoCart(Id,useremail);
            return RedirectToAction("Home","Home");
        }
        public IActionResult ViewCart()
        {
            var s = HttpContext.User.Claims.ToList()[0].Value.ToString();
            var cart = _userRepository.GetCart(s);
            if (cart != null)
            {
                ViewBag.Count = _userRepository.GetAllProductsFromCart(s).Count;
                return View(_userRepository.GetAllProductsFromCart(s));
            }
            else
            {
                ViewBag.Count = 0;
                return View();
            }
        }
        public IActionResult DeletePRoductFromCart(int Id)
        {
            var useremail = HttpContext.User.Claims.ToList()[0].Value;
            _userRepository.DeleteProductFromCart(Id,useremail);
            return RedirectToAction("ViewCart");
        }
    
    }
}
