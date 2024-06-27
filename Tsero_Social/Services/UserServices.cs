using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data;
using Tsero_Social.Dbcontext;
using Tsero_Social.InterFaces;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class UserServices : IuserService
    {
        private readonly UserDbcontext _Context;
        private readonly UploadImg _UploadImg;
        public UserServices(UserDbcontext Context)
        {
            _Context = Context;
        }

        //  Login
        public bool Login(string Email, string Password)
        {
            var user = _Context.Users.FirstOrDefault(u => u.Email == Email);

            if (user != null)
            {
                string hashedPassword = user.Password;
                bool isPasswordCorrect = VerifyPassword(Password, hashedPassword);

                if (isPasswordCorrect)
                {
                    User.Loged_user.Clear(); 
                    User.Loged_user.Add(user);

                    return true;
                }
            }

            return false;
        }


        //  Registration

        public bool Register(User user)
        {
            var register = _Context.Users.Any(u => u.Email == user.Email);
            if(register)
            {              
                return user != null;
            }
            else
            {
                if (user.Username.Length <= 12)
                {
                    var hashed = HashPassword(user.Password);
                    var Register_customer = new User
                    {
                        Email = user.Email,
                        Lastname = user.Lastname,
                        Name = user.Name,
                        Password = hashed,
                        CoverPicture = user.CoverPicture,
                        Isonline = user.Isonline,
                        ProfilePicture = user.ProfilePicture,
                        Username = user.Username,
                    };
                    _Context.Users.Add(Register_customer);
                    _Context.SaveChanges();
                }
                return user == null;
            }
        }
        public string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        //End of Registration


        //Profile update
        public void ProfilePhoto(string path)
        {
            int id = 0;
            foreach (var user in User.Loged_user)
            {
                id = user.id;
            }

            var userToUpdate = _Context.Users.FirstOrDefault(a => a.id == id);
            if (userToUpdate != null)
            {
                userToUpdate.ProfilePicture = path;
                _Context.SaveChanges();
            }
        }

        public List<User> GetUserLogedUsers()
        {
            return User.Loged_user;
        }
        public void ProfileUpdateForm(User user)
        {
            int id = 0;
            foreach(var item in User.Loged_user)
            {
                if (item != null)
                {
                    id = item.id;
                }
            }

            if (user != null)
            {
                var foundUser = _Context.Users.FirstOrDefault(u => u.id == id);
                if (foundUser != null)
                {
                    if (!string.IsNullOrEmpty(user.ProfilePicture))
                    {
                        foundUser.ProfilePicture = user.ProfilePicture;
                    }

                    if (!string.IsNullOrEmpty(user.Name))
                    {
                        foundUser.Name = user.Name;
                    }

                    if (!string.IsNullOrEmpty(user.Username))
                    {
                        foundUser.Username = user.Username;
                    }

                    if (!string.IsNullOrEmpty(user.Lastname))
                    {
                        foundUser.Lastname = user.Lastname;
                    }
                    _Context.SaveChanges();
                }
            }
        }
    }
}



