using Microsoft.AspNetCore.Mvc;
using OnlineRetailManagement.Repository;

namespace OnlineRetailManagement.Controllers
{
    public class OrderController : Controller
    {
        private IUserRepository _userrepository;
            
        public OrderController(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }
        public IActionResult OrderDetails()
        {

            var s = HttpContext.User.Claims.ToList()[0].Value;

            return View(_userrepository.GetAllOrders(s));
        }
    }
}
