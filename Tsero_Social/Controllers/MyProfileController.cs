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
        private readonly IuploadImg _Image;
        private readonly UserDbcontext _userDbcontext;
        private readonly IuserService _userService;
        private readonly IpostService _ipostservice;
        public MyProfileController(IuploadImg upload, UserDbcontext userDbcontext, IuserService userface, IpostService postService)
        {
            _Image = upload;
            _userDbcontext = userDbcontext;
            _userService = userface;
            _ipostservice = postService;
        }


        public IActionResult ProfileGenerate()
        {

            using (var transaction = _userDbcontext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                try
                {
                    var logedUsers = _userService.GetUserLogedUsers();
                    if (logedUsers != null && logedUsers.Any())
                    {
                        ViewBag.Users = _userDbcontext.Users.ToList();
                        ViewBag.Comments = _userDbcontext.Comments.ToList();
                        ViewBag.Likes = _userDbcontext.Likes.ToList();
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
                                var userPosts = _userDbcontext.Posts
                                .Where(p => p.UserID == loggedUser.id)
                                .OrderByDescending(u => u.DateTime)
                                .ToList();

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

            }
            return View("Profile");
        }
        public IActionResult Index()
        {
            ProfileGenerate();
            return View("Profile");
        }
        [HttpGet]
        public IActionResult Profile()
        {
            {
                ProfileGenerate();
                return View("Profile");
            }
        }
        [HttpGet]
        public IActionResult EditCover()
        {
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Profile(ImageUpload model, string title)
        {
            {
                ProfileGenerate();
                _Image.ProfilePicUpload(model ,title);
                return View("Profile");
            }        
        }
        [HttpPost]
        public IActionResult PostPublish( string PostPost, ImageUpload model)
        {
            ProfileGenerate();
            _ipostservice.PostWriting(PostPost, model);
            return View("Profile");
        }
        [HttpGet]
        public IActionResult ProfileUpdate()
        {
            {
                var item = _userService.GetUserLogedUsers();
                int id = 0;
                foreach (var i in item)
                {
                    id = i.id;
                    break;
                }
                var CurrentUser = _userDbcontext.Users.FirstOrDefault(u => u.id == id);
                ViewBag.CurrentUser = CurrentUser;
                return View("ProfIleUpdate");
            }
        }
        [HttpPost]
        public IActionResult ProfileUpdate(User user)
        {
            {
                ProfileGenerate();
                var item = _userService.GetUserLogedUsers();
                int id = 0;
                foreach (var i in item)
                {
                    id = i.id;
                    break;
                }
                var CurrentUser = _userDbcontext.Users.FirstOrDefault(u => u.id == id);
                ViewBag.CurrentUser = CurrentUser;
                _userService.ProfileUpdateForm(user);
                return View("Profile");
            }
        }
        [HttpPost]
        public IActionResult PostDelete(string PostPhoto, int id)
        {
            _ipostservice.DeletePost(id, PostPhoto);
            _Image.DeleteImg(PostPhoto);
            ProfileGenerate();
            return View("Profile");
        }
    }
}
