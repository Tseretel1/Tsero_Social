using Microsoft.EntityFrameworkCore;
using Tsero_Social.Dbcontext;
using Tsero_Social.Migrations;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class postService : IpostService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserDbcontext _dbcontext;
        public postService(IWebHostEnvironment hostingEnvironment, UserDbcontext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbcontext = db;
        }

        private static readonly object lockObject = new object();

        public void PostWriting(string PostPost, ImageUpload model)
        {
            lock (lockObject)
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath + "/" + "UploadedPictures/");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                    string PattoDisplay = $"../UploadedPictures/{uniqueFileName}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    int userid = 0;
                    string title = "";
                    bool Loginedornot = false;
                    foreach (var item in User.Loged_user)
                    {
                        if (item != null)
                        {
                            Loginedornot = true;
                            userid = item.id;
                            title = item.Username;
                        }
                    }
                    
                    if (Loginedornot)
                    {
                        var image = new ImageUpload
                        {
                            ImagePath = filePath,
                            Title = title,
                            PathToDisplay = PattoDisplay,
                            Userid = userid,
                        };
                        _dbcontext.images.Add(image);
                        _dbcontext.SaveChanges();

                        var postupload = new Post
                        {
                            UserID = userid,
                            Photo = PattoDisplay,
                            DateTime = DateTime.Now,
                            post = PostPost,
                        };
                        _dbcontext.Posts.Add(postupload);
                        _dbcontext.SaveChanges();
                    }
                    else
                    {
                        model = null;
                    }
                }
                else
                {
                    int userid = 0;
                    string title = "";
                    foreach (var item in User.Loged_user)
                    {
                        if (item != null)
                        {
                            userid = item.id;
                            title = item.Username;
                        }
                    }
                    var postupload = new Post
                    {
                        UserID = userid,
                        Photo = null,
                        DateTime = DateTime.Now,
                        post = PostPost,
                    };
                    _dbcontext.Posts.Add(postupload);
                    _dbcontext.SaveChanges();
                }
            }
        }

        public void Myposts()
        {

        }
    }
}
