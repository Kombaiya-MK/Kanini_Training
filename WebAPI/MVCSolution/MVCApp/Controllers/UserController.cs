using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserController user)
        {
            return View();
        }
    }
}
