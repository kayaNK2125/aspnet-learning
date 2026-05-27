using FirstMVCWebApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcWebApp.Controllers
{
    public class AuthController : Controller // contoller -> Mvc controller
                                             // ControllerBase -> ApiController
    {
        public AuthController()
        {
            
        }

        public IActionResult Login() //when view is empty it will go to login which is in Auth
        {
            return View();
        }
        public IActionResult Registration() //every page has it own methods
        {
            return View();
        }
        public IActionResult CreateUser(UserDto dto)
        {
            
        }
    }
}
