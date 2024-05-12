using Microsoft.AspNetCore.Mvc;
using Tsero_Social.Models;
using Tsero_Social.Dbcontext;
using Tsero_Social.Services;

namespace Tsero_Social.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserDbcontext _dbcontext;
        private readonly UserServices _userServices;
        private readonly LikeCommentService _LikeComment;
        private readonly Followserivce _followservice;
        public HomeController(IWebHostEnvironment hostingEnvironment, UserDbcontext db, UserServices userService, LikeCommentService likeComment, Followserivce followservice)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbcontext = db;
            _userServices = userService;
            _LikeComment = likeComment;
            _followservice = followservice;
        }
        public IActionResult Index()
        {

            ViewBag.UserPosts = "";
            var allPosts = _dbcontext.Posts
                .Where(p => p.DateTime < DateTime.Now)
                .OrderByDescending(p => p.DateTime)
                .ToList();
            ViewBag.Users = _dbcontext.Users.ToList();
            ViewBag.Comments = _dbcontext.Comments.ToList();
            ViewBag.Likes = _dbcontext.Likes.ToList();
            ViewBag.UserPosts = allPosts;
            ViewBag.Posts = new List<User>();
            ViewBag.CurrentUser = _userServices.GetUserLogedUsers();
            var allUsers = _dbcontext.Users.ToList();
            foreach (var post in allPosts)
            {
                var user = allUsers.FirstOrDefault(u => u.id == post.UserID);
                if (user != null)
                {
                    ViewBag.Posts.Add(user);
                }
            }
            return PartialView("home", allPosts);
        }

        public IActionResult home(int page = 1)
        {
            int pageSize = 5;
            int offset = (page - 1) * pageSize;
            if (offset < 0)
            {
                offset = 0;
            }

            var allPosts = _dbcontext.Posts
                .Where(p => p.DateTime < DateTime.Now)
                .OrderByDescending(p => p.DateTime)
                .Skip(offset)
                .Take(pageSize)
                .ToList();

            ViewBag.Users = _dbcontext.Users.ToList();
            ViewBag.Comments = _dbcontext.Comments.ToList();
            ViewBag.Likes = _dbcontext.Likes.ToList();
            ViewBag.UserPosts = allPosts;
            ViewBag.Posts = new List<User>();
            ViewBag.CurrentUser = _userServices.GetUserLogedUsers();
            var allUsers = _dbcontext.Users.ToList();
            foreach (var post in allPosts)
            {
                var user = allUsers.FirstOrDefault(u => u.id == post.UserID);
                if (user != null)
                {
                    ViewBag.Posts.Add(user);
                }
            }
            return PartialView("home", allPosts);
        }
        public IActionResult Foryou()
        {
            bool IsLogged = true;
            try
            {
                var logedUsers = _userServices.GetUserLogedUsers();
                if (logedUsers.Count > 0)
                {
                    IsLogged = true;
                }

                else if (logedUsers.Count <= 0)
                {
                    IsLogged = false;
                }
            }


            catch (Exception ex)
            {
            }
            if (IsLogged)
            {
                var allPosts = _dbcontext.Posts
                    .Where(p => p.DateTime < DateTime.Now)
                    .OrderByDescending(p => p.DateTime)
                    .ToList();
                ViewBag.Users = _dbcontext.Users.ToList();
                ViewBag.Comments = _dbcontext.Comments.ToList();
                ViewBag.Likes = _dbcontext.Likes.ToList();
                ViewBag.Follows = _dbcontext.Follows.ToList();
                ViewBag.UserPosts = allPosts;
                ViewBag.Posts = new List<User>();
                ViewBag.CurrentUser = _userServices.GetUserLogedUsers();
                var allUsers = _dbcontext.Users.ToList();
                foreach (var post in allPosts)
                {
                    var user = allUsers.FirstOrDefault(u => u.id == post.UserID);
                    if (user != null)
                    {
                        ViewBag.Posts.Add(user);
                    }
                }
                return PartialView("Foryou", allPosts);
            }

            else if (!IsLogged)
            {
                ViewBag.Noposts = "No Post Are available";
                return RedirectToAction("Login", "Login");
            }
            return View("Login");
        }
        [HttpPost]
        public IActionResult Like(int Postid, int CurrentUserID)
        {
            _LikeComment.PostToLike(Postid, CurrentUserID);
            return PartialView("_FollowResult", "Home");
        }
    
        [HttpPost]
        public IActionResult FollowPerson(int FollowerID, int FollowingID)
        {
            try
            {
                _followservice.Follow(FollowerID, FollowingID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while following the person.");
            }
        }
    }
}