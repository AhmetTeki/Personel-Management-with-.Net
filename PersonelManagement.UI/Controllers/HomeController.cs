using Microsoft.AspNetCore.Mvc;

namespace PersonelManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
