using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PracticeWebApp.Controllers
{
    public class ActionResultController : Controller
    {
                   
                                               // Types of ActionResults:

        // 1) ViewResult: Renders a view as a web page.
        public IActionResult Index()
        {
            return View("hello"); // This will look for a view named "Hello.cshtml"
        }


        // 2) PartialViewResult: Renders a partial view, which is a reusable component that can be included in other views.
        //    it can be called using @Html.Partial("ViewName"), Shown in -> hello.cshtml
        public IActionResult MyAds()
        {
            return PartialView(); // This will look for a partial view named "MyAds.cshtml"
        }


        // 3) JsonResult: Returns JSON-formatted data, often used in APIs or when returning data for client-side JavaScript to consume.
        public IActionResult GetData()
        {
            return Json(new { name = "A", Id = 101 });
        }


        // 4) ContentResult: Returns plain text or HTML content directly to the response.
        public IActionResult GetContent(String? id) //we use "?" because parameter is optional, if we don't pass anything it will be null
                                                    //we can only use "id" here because defined it in program.cs as "{controller=ActionResult}/{action=MyAds}/{id?}"
        {
            return Content("This is some plain text content and you wrote:" + id);
        }


        // 5) RedirectResult: Redirects to another action or URL.
        public IActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.com");
        }


        // 6) RedirectToActionResult: Redirects to another action within the same application.
        public IActionResult MyHome()
        {
            return RedirectToAction("home","Guest"); // This will redirect to the "home" action in the "Guest" controller
        }


        // 7) FileResult: Returns a file to the client, which can be used for downloading files.
        public IActionResult Download()
        {
            return File("~/ASPNET_Core_MVC_ActionResults_Summary.pdf", "application/pdf"); // Remember .pdf used in location because it name(in wwwroot) contains .pdf
        }

        // 8) StatusCodeResult: Returns an HTTP status code, which can be used to indicate the result of an action (e.g., 404 Not Found, 500 Internal Server Error).
        public IActionResult Error()
        {
            return StatusCode(404); // This will return a 404 Not Found status code
        }


        // 9) EmptyResult: Represents a result that does not produce any response. It can be used when an action does not need to return any content or perform any redirection.
        public IActionResult DoNothing()
        {
            return new EmptyResult(); // This will return an empty response
        }


        // 10) LocalRedirectResult: Redirects to a local URL, which is useful for preventing open redirect vulnerabilities.
        public IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) // example url: "https://localhost:5001/ActionResult/RedirectToLocal?returnUrl=%2FHome%2FIndex
            {
                return LocalRedirect(returnUrl); // This will redirect to the specified local URL
            }
            else
            {
                return RedirectToAction("Index", "Home"); // If the URL is not local, redirect to a safe default action, example chatgpt.com 
            }
        }
    }
}

/*
 SUMMARY:-
  10 types of ActionResults in ASP.NET Core MVC are:
  1. ViewResult: Renders a view as a web page.
  2. PartialViewResult: Renders a partial view.
  3. JsonResult: Returns JSON-formatted data.
  4. ContentResult: Returns plain text or HTML content.
  5. RedirectResult: Redirects to another action or URL.
  6. RedirectToActionResult: Redirects to another action within the same application.
  7. FileResult: Returns a file to the client.
  8. StatusCodeResult: Returns an HTTP status code.
  9. EmptyResult: Represents a result that does not produce any response.
  10. LocalRedirectResult: Redirects to a local URL.
*/