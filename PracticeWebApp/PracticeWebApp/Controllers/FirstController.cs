//creating a controller in ASP.NET Core MVC
using Microsoft.AspNetCore.Mvc;

namespace PracticeWebApp.Controllers
{
    public class FirstController : Controller //inheritance
    {
        public IActionResult Index() //action method
        {
            return View(); //go to view folder and find the view with the same name as the action method
        }
    }
}
