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
            return View();
        }
        public IActionResult Registration() //every page has it own methods
        {
            return View();
        }
        public async Task<IActionResult> CreateUser(UserDto dto)
        {
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
            return RedirectToAction("Login");
        }
    }
}
