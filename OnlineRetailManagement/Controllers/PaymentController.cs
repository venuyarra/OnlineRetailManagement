using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineRetailManagement.Repository;

namespace OnlineRetailManagement.Controllers
{
    public class PaymentController : Controller
    {
        private IUserRepository _userRepository;

        public PaymentController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Payment(int Id)
        {
            double total = 0;
            var s = HttpContext.User.Claims.ToList()[0].ToString();
            var l = _userRepository.GetAllProductsFromCart(s).ToList();
            foreach(var product in l)
            {
                total += product.TotalPrice;

            }
            ViewBag.Total = total;
            HttpContext.Session.SetInt32("cartid", Id);
           
            return View();
        }
       
        public IActionResult PaymentDone()
        {
            double total = 0;
            var s = HttpContext.User.Claims.ToList()[0].ToString();
            var l = _userRepository.GetAllProductsFromCart(s).ToList();
            foreach (var product in l)
            {
                total += product.TotalPrice;

            }
            int cartid = Convert.ToInt32(HttpContext.Session.GetInt32("cartid"));
            _userRepository.RemoveCart(cartid,total);
            ViewBag.Total = total;
            

            return View();
        }
    }
}
