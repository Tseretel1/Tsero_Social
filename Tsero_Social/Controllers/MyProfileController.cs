using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tsero_Social.Dbcontext;
using Tsero_Social.Migrations;
using Tsero_Social.Models;
using Tsero_Social.Services;

namespace Tsero_Social.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly IuploadImg _uploadimg;
        private readonly UserDbcontext _userDbcontext;
        private readonly IuserService _userService;
        private readonly IpostService _ipostservice;
        public MyProfileController(IuploadImg upload, UserDbcontext userDbcontext, IuserService userface, IpostService postService)
        {
            _uploadimg = upload;
            _userDbcontext = userDbcontext;
            _userService = userface;
            _ipostservice = postService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Profile()
        {
            using (var transaction = _userDbcontext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                try
                {
                    var logedUsers = _userService.GetUserLogedUsers();
                    if (logedUsers != null && logedUsers.Any())
                    {
                        foreach (var user in logedUsers)
                        {
                            var loggedUser = _userDbcontext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                            if (loggedUser != null)
                            {
                                ViewBag.Name = loggedUser.Name;
                                ViewBag.LastName = loggedUser.Lastname;
                                ViewBag.Username = $"@{loggedUser.Username}";
                                ViewBag.Profile = loggedUser.ProfilePicture;
                                ViewBag.isonline = loggedUser.Isonline;
                                ViewBag.NoPosts = "NO Post Available";
                                var userPosts = _userDbcontext.Posts.Where(p => p.UserID == loggedUser.id).ToList();
                                ViewBag.UserPosts = userPosts;

                                break;
                            }
                        }
                    }

                    else
                    {
                        ViewBag.LooginFirst = "Please Login First";
                        return RedirectToAction("Login", "Login");
                    }
                    _userDbcontext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                return View("Profile");
            }
        }

        public IActionResult Profile(ImageUpload model)
        {
            _uploadimg.UploadIMG(model);

            return View("Profile");
        }
        [HttpGet]
        public IActionResult PostPublish()
        {
            return View("Profile");
        }
        [HttpPost]
        public IActionResult PostPublish( string PostPost, ImageUpload model)
        {
            _ipostservice.PostWriting(PostPost, model);
            return View("Profile");
        }
    }
}
