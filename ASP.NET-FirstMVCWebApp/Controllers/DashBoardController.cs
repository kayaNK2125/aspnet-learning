using Microsoft.AspNetCore.Mvc;

namespace FirstMvcWebApp.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
