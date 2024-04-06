using Microsoft.EntityFrameworkCore;
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

        public UserDbcontext(DbContextOptions<UserDbcontext> options) : base(options)
        {

        }
    }
}

