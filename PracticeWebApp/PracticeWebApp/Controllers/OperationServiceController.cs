using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using PracticeWebApp.Models;
using PracticeWebApp.Services;

namespace PracticeWebApp.Controllers
{
    public class OperationServiceController : Controller
    {
        private IOperations _service; //Here "_service" is a private field that holds the service object so we can call its methods (AddTwoNumbers/SubstractTwoNumber) anywhere inside this controller.
        public OperationServiceController(Operations_Service _service) //Constructor. ASP.NET's Dependency Injection automatically creates an Operations_Service and passes it in here when the controller is created.
        {
            this._service = _service; //Store the injected service into the private field above so the rest of the class can use it.
        }
        public IActionResult Index() //HttpGet Meathod to Load View
        {
            Operation_Model model = new Operation_Model(); //Create a fresh, empty model object to send to the view so the form has something to bind to.
            return View(model); //Return the Index.cshtml view and pass the empty model to it (shows the blank form to the user).
        }

        [HttpPost] //After Submit of data

        public IActionResult Index(Operation_Model o, string ope) //"o" is filled with the numbers the user typed (model binding); "ope" receives which button/operator (+ or -) was sent.
        {

            if (ope.Equals("+")) //Check if the chosen operation is addition.
            {
                ViewBag.Result = "Addition Of Two Number is: " + _service.AddTwoNumbers(o.Num1, o.Num2); //Call the service to add the two numbers and store the message in ViewBag so the view can display it.
            }
            else if (ope.Equals("-")) //Check if the chosen operation is Substraction.
            {
                ViewBag.Result = "Substraction Of Two Number is: " + _service.SubstractTwoNumber(o.Num1, o.Num2); //Call the service to subtract the two numbers and put the result message in ViewBag.
            }
            else if (ope.Equals("*"))
            {
                ViewBag.Result = "Multiplication Of Two Number is: " + _service.MultiplyTwoNumber(o.Num1, o.Num2);
            }
            else //Otherwise (any operation that is not "+","-","*"), do Division.
            {
                ViewBag.Result = "Division Of Two Number is: " + _service.DevideTwoNumber(o.Num1, o.Num2);
            }

            Operation_Model model = new Operation_Model(); // Important because we send a fresh empty model back so the form resets/works correctly when the page reloads with the result.
            return View(model); //Reload the Index view, passing the new model; the answer appears via ViewBag.Result.
        }
    }
}
