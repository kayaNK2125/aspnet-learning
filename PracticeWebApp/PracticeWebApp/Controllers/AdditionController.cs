using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using PracticeWebApp.Models;
using PracticeWebApp.Services;

namespace PracticeWebApp.Controllers
{
    public class AdditionController : Controller
    {
        private AdditionService _services;
        public AdditionController(AdditionService _services)
        {
            this._services = _services;
        }
        public IActionResult Index() //HttpGet Meathod to Load View 
        {
            AdditionModel model = new AdditionModel(); 
            return View(model);
        }

        [HttpPost]

        public IActionResult Index(AdditionModel o)
        {
            ViewBag.Result  = _services.AddTwoNumbers(o.Num1 , o.Num2);

            AdditionModel model =new AdditionModel();
            return View(model);
        }
    }
}
