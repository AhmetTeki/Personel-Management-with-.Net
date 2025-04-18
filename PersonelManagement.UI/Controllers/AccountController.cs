using Microsoft.AspNetCore.Mvc;
using PersonelManagement.Application.Dtos;

namespace PersonelManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
