using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace PracticeWebApp.Controllers
{
    public class OperationController : Controller
    {

        [HttpGet] // it's not mandatory to write [HttpGet] (Default)
        public IActionResult Index()
        {
            return View();
        }

        //PARAMETER BY NAME EXAMPLE:-

        /*
            [HttpPost]
            public IActionResult Index(String num1, String num2, String btnsub)
            {

                double a = double.Parse(num1);
                double b = double.Parse(num2);

                if (btnsub.Equals("+")) //btnsub is "+" or not.
                {
                    ViewBag.result = a + b;
                }
                else if (btnsub.Equals("-"))
                {
                    ViewBag.result = a - b;
                }
                else if (btnsub.Equals("*"))
                {
                    ViewBag.result = a * b;
                }
                else
                {
                    ViewBag.Result = a / b;
                }
        */

        // FORM COLLECTION EXAMPLE:-
        /*
        [HttpPost]
        public IActionResult Index(IFormCollection obj)
        {

            double a = double.Parse(obj["num1"]);
            double b = double.Parse(obj["num2"]);

            if (obj["btnsub"].Equals("+")) // obj "btnsub" is "+" or not.
            {
                ViewBag.result = a + b;
            }
            else if (obj["btnsub"].Equals("-"))
            {
                ViewBag.result = a - b;
            }
            else if (obj["btnsub"].Equals("*"))
            {
                ViewBag.result = a * b;
            }
            else
            {
                ViewBag.Result = a / b;
            }
        */

                               // REQUEST.FORM EXAMPLE:-
        [HttpPost]
        public IActionResult IndexPost() // we can give any name to the method but we have to specify the name of the method in the form action attribute in the view.
                                         // method name = "IndexPost" → form's asp-action must be "IndexPost"
        {
            double a = double.Parse(Request.Form["num1"]); // Request.Form is a collection of all the form data that is submitted to the controller.
            double b = double.Parse(Request.Form["num2"]);

            if (Request.Form["btnsub"].Equals("+")) // Request.Form "btnsub" is "+" or not.
            {
                ViewBag.result = a + b; 
            }
            else if (Request.Form["btnsub"].Equals("-"))
            {
                ViewBag.result = a - b;
            }
            else if (Request.Form["btnsub"].Equals("*"))
            {
                ViewBag.result = a * b;
            }
            else
            {
                ViewBag.Result = a / b;
            }
            {
                return View("Index"); // Load Index.cshtml
            }
        }
    }
}

/*
There are in total 4 ways to pass data from view to controller in ASP.NET Core MVC:
1) using model objects - we can create a model class and then we can create an object of that class in the view and then we can pass that object to the controller. 
 This is the most common way to pass data from view to controller in ASP.NET Core MVC.

2) using parameter by name - we can pass data from view to controller by using parameter by name.
 We can create a form in the view and then we can pass the data from that form to the controller by using the name of the input fields in the form.

3) using form collection -we can pass data from view to controller by using form collection. We can create a form in the view and then we can pass the data from that form to the controller by using the FormCollection object.
 This is not recommended way to pass data from view to controller because it is not strongly typed and it can lead to runtime errors if you try to access a property that does not exist.

4) using query string - we can pass data from view to controller by using query string.We can create a link in the view and then we can pass the data from that link to the controller by using the query string.
 This is not recommended way to pass data from view to controller because it can lead to security issues if you are passing sensitive data in the query string.
*/    