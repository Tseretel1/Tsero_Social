
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Diagnostics;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Tsero_Social.Models;
using Microsoft.Extensions.Hosting.Internal;
using Tsero_Social.Dbcontext;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Tsero_Social.Services;

namespace Tsero_Social.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserDbcontext _dbcontext;
        private readonly UserServices _userServices;
        public HomeController(IWebHostEnvironment hostingEnvironment, UserDbcontext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbcontext = db;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 5;
            int offset = (page - 1) * pageSize;
            if (offset < 0)
            {
                offset = 0;
            }

            ViewBag.UserPosts = "";
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

        public IActionResult Foryou(int page = 1)
        {
            bool IsLogged = true;
            try
            {
                var logedUsers = _userServices.GetUserLogedUsers();
                if (logedUsers != null && logedUsers.Any())
                {
                    IsLogged = true;
                }

                else
                {
                    IsLogged = false;
                }

            }

            catch (Exception ex)
            {
            }
            if (IsLogged)
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
            else
            {
                ViewBag.Noposts = "No Post Are available";
            }
            return View("Foryou");
        }
    }
}