using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonelManagement.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
