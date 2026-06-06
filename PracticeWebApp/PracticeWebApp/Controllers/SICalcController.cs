// controller class is used to load the application and to write bussiness logic. It is used to handle the user requests and to return the response to the user. It is also used to interact with the model and the view.

using System.Security.Cryptography.X509Certificates;
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
            return View(obj); //attach model instance to the view. 
        }
        [HttpPost] // POST: /SICalc/ - This method should run only when the browser sends a POST request. 
                   // when we click on submit button in form, browser sends a POST request.
        public IActionResult Index(SI obj)
        {
            double si = (obj._p * obj._r * obj._t) / 100; // SI = (P*R*T)/100 , this obj is not created  by us, it is created by the model binding feature of ASP.NET Core MVC.
            ViewBag.Result = "Result is: " + si; // ViewBag is a dynamic object that allows you to pass data from the controller to the view

            //Viewbag EXAMPLE:-

            ViewBag.a = 21;
            ViewBag.b = 12;    // ~ we can write thies in index.cshtml file also, but we are writing here to show the example of using viewbag.
            ViewBag.c = ViewBag.a + ViewBag.b; //example of using viewbag.

            ViewData["e"] = 2100;
            ViewData["x"] = 25;
            ViewData["n"] = (int)ViewData["e"] + (int)ViewData["x"]; // we need to cast the data when we retrieve it in the view

            return View(); // This will return the same view (Index.cshtml) and display the result in the view using ViewBag.Result.
        }
        //Viewdata EXAMPLE:-  

        // TempData is used to pass data from one request to another request.
        public IActionResult TestData()
                {
            ViewBag.a = "ViewBag data";
            ViewData["a"] = "ViewData data";
            TempData["b"] = "TempData data you can clearly see view bag and view data is not printed";
            TempData.Keep(); // This will keep the TempData for the next request, otherwise it will be cleared after the first request.
            return RedirectToAction("Home","Guest"); // /SICalc/TestData => /Home/Guest page will open and we can access the TempData in that page.
        }
        }
}

/*

There are 3 ways to pass data from Controller to View in ASP.NET Core MVC: 

1) ViewBag - It is a dynamic object that allows you to pass data from the controller to the view. Stores both Data as well as Type information. It is not strongly typed, so you can add any type of data to it without any compile-time checking.
It is not recommended to use ViewBag for passing large amount of data or complex data structures, because it can lead to performance issues and it can also lead to runtime errors if you try to access a property that does not exist. 

2) ViewData - It is a dictionary object that allows you to pass data from the controller to the view. Stores only Data information , not Type information. It is not strongly typed. ViewData passes data from Controller to View. Casting may be required when retrieving values.
It is not recommended to use ViewData for passing large amount of data or complex data structures, because it can lead to performance issues and it can also lead to runtime errors if you try to access a property that does not exist.

3) TempData - It is a dictionary object that allows you to pass data from one request to another request. It is a property of the Controller class and it is available in all the views.It is a strongly typed, so you need to cast the data when you retrieve it in the view. It is not recommended to use TempData for passing large amount of data or complex data structures, because it can lead to performance issues and it can also lead to runtime errors if you try to access a property that does not exist.


strongly typed = the compiler lnows the exact type and yells at you use it wrong.
weekly typed = you only find out it's wrong when the app runs.

*/
