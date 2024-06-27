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
                var IF_Following = _Context.Follows.FirstOrDefault(u=> u.User1 == Follower.id && u.User2 == Following.id);
                if (IF_Following != null)
                {
                    _Context.Follows.Remove(IF_Following);
                    _Context.SaveChanges();
                }
                else
                {
                    var Follow = new Models.Follows
                    {
                        User1 = Follower.id,
                        User2 = Following.id,
                    };
                    _Context.Follows.Add(Follow);
                    _Context.SaveChanges();
                    int type = 2;
                    var NewNotification = new Notificationss()
                    {
                        User1 = FollowerID,
                        User2 = FollowingID,
                        DateTime = DateTime.Now,
                        Type = type,
                    };
                    _Notifycations.Notification(NewNotification);
                }
            }
        }

        public void RemoveFollower(int UserToRmoveID, int MyID)
        {
            var IFfollowExists = _Context.Follows.FirstOrDefault(u => u.User1 == UserToRmoveID && u.User2 == MyID);
            if (IFfollowExists != null)
            {
                _Context.Follows.Remove(IFfollowExists);
                _Context.SaveChanges();
            }
            else if(IFfollowExists == null)
            {
                var NewFollower = new Models.Follows
                {
                    User1 = UserToRmoveID,
                    User2= MyID
                };
                _Context.Follows.Add(NewFollower);
                _Context.SaveChanges();
            }
        }

        public void RemoveFollowing(int FollowingToDelete, int MyID)
        {
            var IFfollowExists = _Context.Follows.FirstOrDefault(u => u.User2 == FollowingToDelete && u.User1== MyID);
            if (IFfollowExists != null)
            {
                _Context.Follows.Remove(IFfollowExists);
                _Context.SaveChanges();
            }
            else if (IFfollowExists == null)
            {
                var NewFollower = new Models.Follows
                {
                     User2 = FollowingToDelete,
                     User1 = MyID
                };
                _Context.Follows.Add(NewFollower);
                _Context.SaveChanges();
            }
            
        }
    }
}
