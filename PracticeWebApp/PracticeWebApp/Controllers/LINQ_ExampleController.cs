/* #LAMBDA EXPRESSION
 LINQ = a way to search, filter, sort, and manipulate collections of data.
 It is used to do Clean coding , less lines of code, and more readable code.

 LINQ has two syntax styles:
1) Query syntax: Similar to SQL, it is more declarative and easier to read for complex queries.
    EXAMPLE:-
        var even =
             from n in numbers (from numbers)
             where n % 2 == 0  (where even)
             select n;         (select numbers)

2) Method syntax: Uses extension methods and lambda expressions, it is more concise and often preferred for simple queries.
    EXAMPLE:- 
        var even = numbers.Where(n => n % 2 == 0);

3) Mixed syntax: Combines both query and method syntax, allowing developers to choose the most suitable style for different parts of a query.
    EXAMPLE:-
        var result =
             (from n in numbers
              where n > 2
              select n)
              .OrderBy(n => n); 

Important LINQ Meathods:
*1) Where: Filters a collection based on a specified condition.
    var even = numbers.Where(n => n % 2 == 0); -> This will return all even numbers from the 'numbers' collection.

*2) FirstOrDefault(): Returns the first element of a collection that satisfies a specified condition, or a default value if no such element is found. 
    var result = numbers.FirstOrDefault(n => n > 3);

*3) OrderBy(): Sorts a collection in ascending order based on a specified key.
    var sorted = numbers.OrderBy(n => n); -> This will sort the 'numbers' collection in ascending order.

 4) OrderByDescending(): Sorts a collection in descending order based on a specified key.
    var sortedDesc = numbers.OrderByDescending(n => n); -> This will sort the 'numbers' collection in descending order.
 
*5) Select(): Projects each element of a collection into a new form.
    var squares = numbers.Select(n => n * n); -> This will create a new collection containing the squares of the numbers in the 'numbers' collection.
    var names = students.Select(s => s.Name); -> This will create a new collection containing the like "Give me only names" from the 'students' collection.
 
*6) Count(): Returns the number of elements in a collection, optionally based on a specified condition.
    int count = numbers.Count(); -> This will return the total number of elements in the 'numbers' collection.
 
 7) Any(): Determines whether any elements of a collection satisfy a specified condition.
    bool hasEven = numbers.Any(n => n % 2 == 0); -> This will return true if there is at least one even number in the 'numbers' collection, otherwise it will return false.
 */


using Microsoft.AspNetCore.Mvc;
using PracticeWebApp.Models;

namespace PracticeWebApp.Controllers
{
    public class LINQ_ExampleController : Controller
    {
        public IActionResult Index()
        {
            string[] arr = { "INDIA", "USA", "CHINA", "JAPAN", "" };
            //var s = arr.Where(x => x.Length > 5); // Length greater than 5
            //var s = arr.Where(x => x.StartsWith("I") || x.StartsWith("C")); // Start with I or C
            var s = from c in arr where c.StartsWith("I") select c; // Start with I

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            var evenNumbers = numbers.Where(n => n % 2 == 0); // Get even numbers
            var squareNumbers = numbers.Select(n => n * n);
            
            ViewBag.squareNumbers = squareNumbers;
            ViewBag.evenNumbers = evenNumbers;
            ViewBag.data = s;
            return View();
        }
        public IActionResult CollectionExample()
        {
            List<LINQ_Employe_Model> obj = new List<LINQ_Employe_Model>
            {
               new LINQ_Employe_Model { Id = 1, Name = "John", Department = "HR", Salary = 50000 },
               new LINQ_Employe_Model { Id = 2, Name = "Jane", Department = "IT", Salary = 60000 },
               new LINQ_Employe_Model { Id = 3, Name = "Doe", Department = "Finance", Salary = 55000 },
               new LINQ_Employe_Model { Id = 4, Name = "Smith", Department = "IT", Salary = 70000 },
            };
            return View(obj.ToList());// ToList() is used to convert the collection to a List, which is often required for data binding in views.
        }
    }
}
