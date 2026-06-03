using Microsoft.AspNetCore.Mvc;
using PracticeWebApp.Models; // including the model class SI from Models folder. This is required to create an object of SI class in this controller.
namespace PracticeWebApp.Controllers
{
    public class SICalcController : Controller
    {
        [HttpGet] // GET: /SICalc/ in more easy - This method should run only when the browser sends a GET request.
                  // when open https://localhost:5001/SICalc browser sends a GET request. 
        public IActionResult Index()
        {
            SI obj = new SI(); // Name should be same of models!
            return View(obj);
        }
        [HttpPost] // POST: /SICalc/ - This method should run only when the browser sends a POST request. 
                   // when we click on submit button in form, browser sends a POST request.
        public IActionResult Index(SI obj)
        {
            double si = (obj._p * obj._r * obj._t) / 100; // SI = (P*R*T)/100   
            ViewBag.Result = "Result is: " + si; // ViewBag is a dynamic object that allows you to pass data from the controller to the view.
            return View(); // This will return the same view (Index.cshtml) and display the result in the view using ViewBag.Result.
        }
    }
}
