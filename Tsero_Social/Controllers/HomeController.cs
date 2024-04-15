
﻿using Microsoft.AspNetCore.Mvc;
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
        public HomeController(IWebHostEnvironment hostingEnvironment, UserDbcontext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbcontext = db;
        }
        public IActionResult Index()
        {
            var allPosts = _dbcontext.Posts.Where(p => p.DateTime < DateTime.Now).ToList();
            var random = new Random();
            var randomPosts = allPosts.OrderBy(x => random.Next()).ToList();



            ViewBag.UserPosts = randomPosts;
            ViewBag.Posts = new List<User>();
            var allUsers = _dbcontext.Users.ToList();
            foreach (var post in randomPosts)
            {
                var user = allUsers.FirstOrDefault(u => u.id == post.UserID);
                if (user != null)
                {
                    ViewBag.Posts.Add(user);
                }
            }

            return View("Home");
        }


        public IActionResult home()
        {
            var allPosts = _dbcontext.Posts.Where(p => p.DateTime < DateTime.Now).ToList();
            var random = new Random();
            var randomPosts = allPosts.OrderBy(x => random.Next()).ToList();

            ViewBag.Users = _dbcontext.Users.ToList();
            ViewBag.Comments = _dbcontext.Comments.ToList();
            ViewBag.UserPosts = randomPosts;
            ViewBag.Posts = new List<User>();
            var allUsers = _dbcontext.Users.ToList();
            foreach (var post in randomPosts)
            {
                var user = allUsers.FirstOrDefault(u => u.id == post.UserID);
                if (user != null)
                {
                    ViewBag.Posts.Add(user);
                }
            }
            return View("home");
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}