
using Microsoft.AspNetCore.Mvc;

using PersonelManagement.Application.Requests;

namespace PersonelManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest dto)
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
