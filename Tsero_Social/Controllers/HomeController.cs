
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
            var userPosts = _dbcontext.Posts
                .Where(p => p.DateTime < DateTime.Now)
                .OrderByDescending(p => p.DateTime)
                .ToList();

            ViewBag.UserPosts = userPosts;
            ViewBag.Posts = new List<User>();
            foreach (var post in userPosts)
            {
                var user = _dbcontext.Users.FirstOrDefault(u => u.id == post.UserID);
                if (user != null)
                {
                    ViewBag.Posts.Add(user);
                }
            }

            return View("Home");
        }


        public IActionResult home()
        {
            var userPosts = _dbcontext.Posts
               .Where(p => p.DateTime < DateTime.Now)
               .OrderByDescending(p => p.DateTime)
               .ToList();

            ViewBag.UserPosts = userPosts;
            return View("home");
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}