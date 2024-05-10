using Microsoft.AspNetCore.Mvc;
using Tsero_Social.Models;
using Tsero_Social.Services;

namespace Tsero_Social.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserServices _userService;
        public LoginController(UserServices tuitionService)
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
            var ragaca =  _userService.GetUserLogedUsers().ToList();
            ragaca.Clear();           
            return View();
        }
        [HttpGet]
        public IActionResult Exit()
        {
            var ragaca = _userService.GetUserLogedUsers();
            ragaca.Clear();
            return View("Login");
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
                ViewBag.EmailExist = "This Email is Already Registered";
                return View("Login");
            }
            else
            {
                if (user.Username.Length > 12 )
                {
                    ViewBag.EmailExist = "UserName Must Contain Less Than 12 Characters!";
                    return View("Login");
                }
                if ( user.Name.Length > 12 )
                {
                    ViewBag.EmailExist = "Name Must Contain Less Than 12 Characters!";
                    return View("Login");
                }
                if (user.Lastname.Length > 12)
                {
                    ViewBag.EmailExist = "LastName Must Contain Less Than 12 Characters!";
                    return View("Login");
                }
                ViewBag.SuccessAlert = "You successfully Registered in our App!";
                return View("Login");
            }
        }

    }
}