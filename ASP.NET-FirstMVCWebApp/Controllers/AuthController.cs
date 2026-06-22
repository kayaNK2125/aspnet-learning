using FirstMvcWebApp.Data;
using FirstMVCWebApp.Dto;
using FirstMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMvcWebApp.Controllers
{
    public class AuthController(AppDbContext _context) : Controller // contoller -> Mvc controller
                            // DI Short Way 👆                    // ControllerBase -> ApiController
    {


        //  private readonly AppDbContext _context; //Dependency Injection
        // public AuthController(AppDbContext context)
        // {
        //     _context = context;
        // }

        public IActionResult Login() //when view is empty it will go to login which is in Auth
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"]; // TempData is used to pass data from one action to another action, it is used to pass data from CreateUser to Login, it is used to display success message after user registration.
            return View();
        }
        public IActionResult Registration() //every page has it own methods
        {
            return View();
        }
        public async Task<IActionResult> CreateUser(UserDto dto)
        {
            if(dto == null || string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password)) {
                ViewBag.ErrorMessage = "Kindly Fill All The Details";
                return View("Registration");
            }
            
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
           if (existingUser == null)
            {
                var user = new User
                {
                    Email = dto.Email,
                    password = dto.Password,
                    Username = dto.Username
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                                                         
            }
           else
            {
                ViewBag.ErrorMessage = "User With This Email Already Exists";
                return View("Registration");
            }
            TempData["SuccessMessage"] = "Registration Successful. Please Login.";
            //return View("Login");   //URL Will Not Change
            return RedirectToAction("Login");

        }

        public async Task<IActionResult> LoginUser(UserDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
            {
                ViewBag.ErrorMessage = "Kindly Fill All The Details";
                return View("Login");
            }
          
                var isUserExist = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
                if (isUserExist == null)
                {
                    ViewBag.ErrorMessage = "User With This Email Does Not Exist";
                    return View("Login");
                }
                else
                {
                    if (isUserExist.password == dto.Password)
                    {
                        return RedirectToAction("Index", "DashBoard");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Invalid Password";
                        return View("Login");
                    }
                }
            
        }
    }
}
