using Microsoft.AspNetCore.Mvc;

namespace ui.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
