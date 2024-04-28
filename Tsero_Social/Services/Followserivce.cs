using Tsero_Social.Dbcontext;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class Followserivce : IfollowService
    {
        private readonly UserDbcontext _Context;
        public Followserivce(UserDbcontext Context)
        {
            _Context = Context;
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
                    var Follow = new Follow
                    {
                        FollowerID = Follower.id,
                        FollowingID = Following.id
                    };
                    _Context.Follows.Add(Follow);
                    _Context.SaveChanges();
                }
            }
        }
    }
}
