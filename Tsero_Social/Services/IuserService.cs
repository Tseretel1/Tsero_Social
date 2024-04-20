using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public interface IuserService
    {
        bool Login(string Email, string Password);
        bool Register(User user);
        void ProfilePhoto(string Path);
        void ProfileUpdateForm(User user);
        public List<User> GetUserLogedUsers();
    }
}
