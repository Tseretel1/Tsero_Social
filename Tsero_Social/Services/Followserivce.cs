using Tsero_Social.Dbcontext;
using Tsero_Social.InterFaces;
using Tsero_Social.Migrations;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class Followserivce : IfollowService
    {
        private readonly UserDbcontext _Context;
        private readonly NotificationsServices _Notifycations;
        public Followserivce(UserDbcontext Context, NotificationsServices n)
        {
            _Context = Context;
            _Notifycations = n;
        }

        public void Follow(int FollowerID, int FollowingID)
        {
            var Follower = _Context.Users.FirstOrDefault(u=>u.id == FollowerID);
            var Following = _Context.Users.FirstOrDefault(u=>u.id ==FollowingID);
            if(Follower != null && Following != null && FollowerID != FollowingID)
            {
                var IF_Following = _Context.Follows.FirstOrDefault(u=> u.FollowerID == Follower.id && u.FollowingID == Following.id);
                if (IF_Following != null)
                {
                    _Context.Follows.Remove(IF_Following);
                    _Context.SaveChanges();
                }
                else
                {
                    var Follow = new Models.FollowFriends
                    {
                        FollowerID = Follower.id,
                        FollowingID = Following.id
                    };
                    _Context.Follows.Add(Follow);
                    _Context.SaveChanges();
                    int type = 2;
                    var NewNotification = new Notificationss()
                    {
                        User1 = FollowerID,
                        User2 = FollowingID,
                        Seen = false,
                        DateTime = DateTime.Now,
                        Type = type,
                        userid = FollowerID
                    };
                    _Notifycations.Notification(NewNotification);
                }
            }
        }

        public void RemoveFollower(int UserToRmoveID, int MyID)
        {
            var IFfollowExists = _Context.Follows.FirstOrDefault(u => u.FollowerID == UserToRmoveID && u.FollowingID == MyID);
            if (IFfollowExists != null)
            {
                _Context.Follows.Remove(IFfollowExists);
                _Context.SaveChanges();
            }
            else if(IFfollowExists == null)
            {
                var NewFollower = new Models.FollowFriends
                {
                    FollowerID = UserToRmoveID,
                    FollowingID = MyID
                };
                _Context.Follows.Add(NewFollower);
                _Context.SaveChanges();
            }
        }

        public void RemoveFollowing(int FollowingToDelete, int MyID)
        {
            var IFfollowExists = _Context.Follows.FirstOrDefault(u => u.FollowingID == FollowingToDelete && u.FollowerID == MyID);
            if (IFfollowExists != null)
            {
                _Context.Follows.Remove(IFfollowExists);
                _Context.SaveChanges();
            }
            else if (IFfollowExists == null)
            {
                var NewFollower = new Models.FollowFriends
                {
                     FollowingID = FollowingToDelete,
                     FollowerID = MyID
                };
                _Context.Follows.Add(NewFollower);
                _Context.SaveChanges();
            }
        }
    }
}
