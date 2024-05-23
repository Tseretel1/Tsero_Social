﻿using Microsoft.EntityFrameworkCore;
using Tsero_Social.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsero_Social.Dbcontext
{
    public class UserDbcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post>Posts { get; set; }
        public DbSet<ImageUpload> images { get; set; }
        public DbSet<VideoUpload> videos { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Notificationss> Notifications { get; set; }
        public UserDbcontext(DbContextOptions<UserDbcontext> options) : base(options)
        {


        }
    }
}

