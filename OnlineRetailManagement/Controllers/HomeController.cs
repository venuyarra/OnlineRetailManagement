using Microsoft.AspNetCore.Mvc;
using OnlineRetailManagement.Models;
using OnlineRetailManagement.Repository;
using System.Diagnostics;

namespace OnlineRetailManagement.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    
        public IActionResult Home()
        {
            return View(_userRepository.GetAllProducts());
        }
    }
}