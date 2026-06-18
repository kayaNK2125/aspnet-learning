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


using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using PracticeWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticeWebApp.Controllers
{
    public class LINQ_ExampleController : Controller
    {
        private readonly PracticeDBContext _logge;  // Dependency injection of the PracticeDBContext to access the database context
        public LINQ_ExampleController(PracticeDBContext logger)  // Constructor to initialize the PracticeDBContext through dependency injection
        {
            _logge = logger; // Assign the injected PracticeDBContext to the private field _logge for use in the controller's actions
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(LINQ_Employe_Model model)
        {
            _logge.LINQ_Employes.Add(model); // Add the new employee model to the LINQ_Employes DbSet in the database context
            _logge.SaveChanges(); // Save the changes to the database
            return RedirectToAction("CollectionExample");
        }

        public IActionResult FindEmployee(int id)
        {
            var obj = _logge.LINQ_Employes.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult FindEmployee(LINQ_Employe_Model obj)
        {
          _logge.Entry(obj).State = EntityState.Modified; // Mark the employee model as modified in the database context
            _logge.SaveChanges(); // Update the existing employee model in the LINQ_Employes DbSet in the database context
            return RedirectToAction("CollectionExample");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var obj = _logge.LINQ_Employes.Find(id); // Find the employee with the specified id in the LINQ_Employes DbSet
                _logge.LINQ_Employes.Remove(obj); // Remove the found employee from the LINQ_Employes DbSet
             _logge.SaveChanges();
            return RedirectToAction("CollectionExample");
        }

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
            var obj = _logge.LINQ_Employes.ToList(); // Fetch all employees from the database and convert it to a list
                       // OR :-
           //var obj = (from c in _logge.LINQ_Employes select c).ToList(); // Fetch all employees from the database using query syntax

            return View(obj);

            /*
              List<LINQ_Employe_Model> obj = new List<LINQ_Employe_Model>
              {
                 new LINQ_Employe_Model { Id = 1, Name = "John", Department = "HR", Salary = 50000 },
                 new LINQ_Employe_Model { Id = 2, Name = "Jane", Department = "IT", Salary = 60000 },
                 new LINQ_Employe_Model { Id = 3, Name = "Doe", Department = "Finance", Salary = 55000 },
                 new LINQ_Employe_Model { Id = 4, Name = "Smith", Department = "IT", Salary = 70000 },
              };
            

            //var obj1 = obj.Where(e => e.Department == "IT"); // Get employees from IT department

            //var obj1 = obj.OrderByDescending(e => e.Salary); // Salary in descending order

            //var obj1 = obj.OrderByDescending(e => e.Salary).ThenByDescending(e => e.Department); // Salary in descending order and then by Department in descending order

            //var obj1 = obj.Where(e => e.Department == "IT").First(); // First employee from IT department if exists, otherwise it will throw an exception.

            var obj1 = obj.Where(e => e.Department == "I").FirstOrDefault(); // First employee from IT department if exists, otherwise it will return null.
            if (obj1 != null)
            {
                ViewBag.data = "ID is " + obj1.Id + ", Name is " + obj1.Name;
            }
            else
            {
                ViewBag.data = "No employee found in IT department.";
            }
            
            //ViewBag.data = "ID is " + obj1.Id + ", Name is " + obj1.Name; 

            var itEmployee = obj.Where(e => e.Department == "IT"); 
            return View(itEmployee.ToList());// ToList() is used to convert the collection to a List, which is often required for data binding in views.
         */


        }

        public IActionResult GroupByExample()
        {
            List<LINQ_Employe_Model> obj = new List<LINQ_Employe_Model>
            {
               new LINQ_Employe_Model { Id = 1, Name = "John", Department = "HR", Salary = 50000 },
               new LINQ_Employe_Model { Id = 2, Name = "Jane", Department = "IT", Salary = 60000 },
               new LINQ_Employe_Model { Id = 3, Name = "Doe", Department = "Finance", Salary = 55000 },
               new LINQ_Employe_Model { Id = 4, Name = "Smith", Department = "IT", Salary = 70000 },
            };

            var groupRecord = obj.GroupBy(e => e.Department) // Group the employees by their department
                .Select(g => new CountEmp // Select a new object of type CountEmp for each group
                {
                Deptname = g.Key,      // The key of the group is the department name
                TotalEmp = g.Count()   // The total number of employees in each department is the count of the group
                });

            return View(groupRecord.ToList());
        }

        public IActionResult JoinExample() 
        {
            List<Course> course = new List<Course>
            {
               new Course { CourseId = 1, CourseName = "C-Sharp" },
               new Course { CourseId = 2, CourseName = "Python" },
               new Course { CourseId = 3, CourseName = "C-Sharp" },
               new Course { CourseId = 4, CourseName = "Java" },
            };

            List<Studentcs> student = new List<Studentcs>
            {
               new Studentcs { Id = 101, Name = "Alice", CID = 1 },
               new Studentcs { Id = 102, Name = "Bob", CID = 2 },
               new Studentcs { Id = 103, Name = "Charlie", CID = 3 },
               new Studentcs { Id = 104, Name = "David", CID = 4 },
            };

            var result = student.Join(course, s => s.CID, c => c.CourseId, (s, c) => new joinResult // Join the student and course collections based on the CID and CourseId and select a new object of type joinResult for each matching pair
            {
                StudentName = s.Name, // Select the student name
                CourseName = c.CourseName,  // Select the course namex`   
                   
              });
            return View(result.ToList());
        }
    }
}
