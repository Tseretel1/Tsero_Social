using Microsoft.AspNetCore.Mvc;
using Tsero_Social.Models;
using Tsero_Social.Services;

namespace Tsero_Social.Controllers
{
    public class LoginController : Controller
    {
        private readonly IuserService _userService;
        public LoginController(IuserService tuitionService)
        {
            _userService = tuitionService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            bool isAuthenticated = _userService.Login(Email, Password);
            if (isAuthenticated)
            {
                return RedirectToAction("Profile", "MyProfile");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return View();
            }
        }


        [HttpPost]
        public IActionResult Register(User user)
        {
            bool isAuthenticated = _userService.Register(user);
            if (isAuthenticated)
            {
                ViewBag.ErrorAlert = "User with given Email already Exist!";
                return View("Login");
            }
            else
            {
                ViewBag.SuccessAlert = "You successfully Registered in our App!";
                return View("Login");
            }
        }

    }
}