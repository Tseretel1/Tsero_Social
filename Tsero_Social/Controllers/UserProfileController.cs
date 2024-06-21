using Microsoft.AspNetCore.Mvc;
using Tsero_Social.Dbcontext;
using Tsero_Social.InterFaces;
using Tsero_Social.Services;

namespace Tsero_Social.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserDbcontext _userDbcontext;
        public UserProfileController(UserDbcontext userDbcontext)
        {
            _userDbcontext = userDbcontext;

        }

        [HttpPost]
        public IActionResult UserProfileGenerate(int UserID)
        {
            {
                try
                {
                    var logedUser = _userDbcontext.Users.Where(u=>u.id == UserID).FirstOrDefault();
                    if (logedUser != null)
                    {
                        ViewBag.Users = _userDbcontext.Users.ToList();
                        ViewBag.Comments = _userDbcontext.Comments.ToList();
                        ViewBag.Likes = _userDbcontext.Likes.ToList();
                        ViewBag.CurrentUser = _userDbcontext.Users.Where(u => u.id == UserID).ToList();
                        if (logedUser != null)
                        {
                            ViewBag.Name = logedUser.Name;
                            ViewBag.LastName = logedUser.Lastname;
                            ViewBag.Username = $"@{logedUser.Username}";
                            ViewBag.Profile = logedUser.ProfilePicture;
                            ViewBag.Cover = logedUser.CoverPicture;
                            ViewBag.isonline = logedUser.Isonline;
                            ViewBag.NoPosts = "NO Post Available";


                            var Followers = _userDbcontext.Follows.Where(u => u.FollowingID == logedUser.id).ToList();
                            ViewBag.MyFollowers = Followers;
                            var Following = _userDbcontext.Follows.Where(u => u.FollowerID == logedUser.id).ToList();
                            ViewBag.MyFollowings = Following;
                            var FollowersCount = _userDbcontext.Follows.Where(u => u.FollowingID == logedUser.id).Count();
                            var FollowingCount = _userDbcontext.Follows.Where(u => u.FollowerID == logedUser.id).Count();
                            ViewBag.Followers = FollowersCount;
                            ViewBag.Following = FollowingCount;

                            var NotificationCount = _userDbcontext.Notifications.Where(u => u.User1 == logedUser.id || u.User2 == logedUser.id).Count();
                                ViewBag.Notification = NotificationCount;

                                var Notification = _userDbcontext.Notifications.Where(u => u.User1== logedUser.id || u.User2 == logedUser.id).ToList();
                                ViewBag.MyNotifications = Notification;
                                var userPosts = _userDbcontext.Posts
                                .Where(p => p.UserID == logedUser.id)
                                .OrderByDescending(u => u.DateTime)
                                .ToList();

                                ViewBag.UserPosts = userPosts;
                        }
                    }
                    _userDbcontext.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                return View("OtherUserProfile");
            }
        }
    }
}
