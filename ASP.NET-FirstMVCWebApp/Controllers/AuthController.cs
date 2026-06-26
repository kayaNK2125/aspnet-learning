using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FirstMvcWebApp.Data;
using FirstMVCWebApp.Dto;
using FirstMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

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
                    var token = GenerateJwtToken(dto); // Generate JWT token for the user if password is correct and user exists

                    Response.Cookies.Append("jwt_Token", token, new CookieOptions // Set the JWT token in a cookie with HttpOnly
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddHours(1)
                    });

                        return RedirectToAction("Index", "DashBoard");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Invalid Password";
                        return View("Login");
                    }
                }
            
        }
        private string GenerateJwtToken(UserDto dto)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("CqMHaCgQsySftoZrYg0nBbiW2hqw78YuK92ONuWqdyU");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                    {

                        new Claim(ClaimTypes.Name, dto.Email), // storing email in claim to identify user

                    }),
                Expires = DateTime.UtcNow.AddMinutes(30), // token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);
            return jwtHandler.WriteToken(token);
        }

        public IActionResult LogoutUser()
        {
            Response.Cookies.Delete("jwt_Token");  // Delete Cookie -> Server no longer knows who you are
            return RedirectToAction("Login");
        }
    }
}
