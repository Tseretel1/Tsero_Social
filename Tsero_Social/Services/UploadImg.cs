using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Tsero_Social.Dbcontext;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class UploadImg : IuploadImg
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserDbcontext _dbcontext;
        private readonly IuserService _userService;
        public UploadImg(IWebHostEnvironment hostingEnvironment, UserDbcontext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbcontext = db;
        }

        private static readonly object lockObject = new object();

        public void UploadIMG(ImageUpload model)
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
                    bool Loginedornot =false;
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
