using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Tsero_Social.Dbcontext;
using Tsero_Social.Models;
using System.IO;
using Tsero_Social.InterFaces;

namespace Tsero_Social.Services
{
    public class UploadImg : IuploadImg
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private static readonly object lockObject = new object();
        private readonly UserDbcontext _dbcontext;
        public UploadImg(IWebHostEnvironment hostingEnvironment, UserDbcontext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbcontext = db;
        }
        public void ProfilePicUpload(ImageUpload model, string title)
        {
            lock (lockObject)
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath + "/" + "ProfilePictures/");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                    string PattoDisplay = $"../ProfilePictures/{uniqueFileName}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    int userid = 0;
                    bool Loginedornot =false;
                    foreach (var item in User.Loged_user)
                    {
                        if (item != null)
                        {
                            Loginedornot = true;
                            userid = item.id;
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

                        var logedUsers = User.Loged_user;
                        foreach (var user in logedUsers)
                        {

                            if (!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
                            {
                                var loggedUser = _dbcontext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                                if (loggedUser != null)
                                {
                                    loggedUser.ProfilePicture = PattoDisplay;
                                    _dbcontext.SaveChanges();
                                    break;
                                }
                            }
                        }
                        int UpdatedProfile = 1;
                        var post = new Post
                        {
                            DateTime = DateTime.Now,
                            Photo = PattoDisplay,
                            UserID = userid,
                            post = title,
                            PostType = UpdatedProfile,
                        };
                        _dbcontext.Posts.Add(post);
                        _dbcontext.SaveChanges();
                    }
                    else
                    {
                        model = null;
                    }
                }
            }
        }

         public void DeleteImg(string PostPhoto)
         {
            var FoundImage = _dbcontext.images.FirstOrDefault(u => u.PathToDisplay == PostPhoto);
            string Image_To_delete = "";
            if(FoundImage != null)
            {
               _dbcontext.images.Remove(FoundImage);
               _dbcontext.SaveChanges();
                Image_To_delete = FoundImage.ImagePath;
            }
            if (!string.IsNullOrEmpty(Image_To_delete) && File.Exists(Image_To_delete))
            {
                File.Delete(Image_To_delete);
            }
         }

        public void UploadCover(ImageUpload model)
        {
            lock (lockObject)
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath + "/" + "CoverPictures/");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                    string PattoDisplay = $"../CoverPictures/{uniqueFileName}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    var existingCover = _dbcontext.Users
                        .Where(u => u.CoverPicture == PattoDisplay)
                        .FirstOrDefault();

                    if (existingCover != null)
                    {
                        var existingFilePath = Path.Combine(_hostingEnvironment.WebRootPath, existingCover.CoverPicture.TrimStart('~', '/'));
                        if (File.Exists(existingFilePath))
                        {
                            File.Delete(existingFilePath);
                        }
                        existingCover.CoverPicture = null;
                        _dbcontext.SaveChanges();
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    int userid = 0;
                    bool Loginedornot = false;
                    foreach (var item in User.Loged_user)
                    {
                        if (item != null)
                        {
                            Loginedornot = true;
                            userid = item.id;
                        }
                    }

                    if (Loginedornot)
                    {
                        var image = new ImageUpload
                        {
                            ImagePath = filePath,
                            Title = null,
                            PathToDisplay = PattoDisplay,
                            Userid = userid,
                        };
                        _dbcontext.images.Add(image);
                        _dbcontext.SaveChanges();

                        var loggedUser = _dbcontext.Users.FirstOrDefault(u => u.id == userid);
                        if (loggedUser != null)
                        {
                            loggedUser.CoverPicture = PattoDisplay;
                            _dbcontext.SaveChanges();
                        }
                    }
                    else
                    {
                        model = null;
                    }
                }
            }
        }
    }
}
