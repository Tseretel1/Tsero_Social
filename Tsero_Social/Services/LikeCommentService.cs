using Tsero_Social.Dbcontext;
using Tsero_Social.InterFaces;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class LikeCommentService : ILikeCommentService
    {
        private readonly UserDbcontext _dbcontext;
        public LikeCommentService(IWebHostEnvironment hostingEnvironment, UserDbcontext db)
        {
           _dbcontext = db;
        }

        public int GetLikeCount(int postId)
        {
            return _dbcontext.Likes.Count(l => l.PostID == postId);
        }

        public bool IsPostLikedByUser(int postId, int userId)
        {
            return _dbcontext.Likes.Any(l => l.PostID == postId && l.UserID == userId);
        }


        public void PostToLike(int Postid, int CurrentUserID)
        {
            if(CurrentUserID != 0 && Postid != null)
            {
                var IfAlreadyLiked = _dbcontext.Likes.FirstOrDefault(u=> u.UserID == CurrentUserID && u.PostID ==Postid);
                if(IfAlreadyLiked != null)
                {
                    _dbcontext.Likes.Remove(IfAlreadyLiked);
                    _dbcontext.SaveChanges();
                }
                else
                {
                    Likes likes = new Likes();
                    likes.UserID = CurrentUserID;
                    likes.PostID = Postid;
                    _dbcontext.Likes.Add(likes);
                    _dbcontext.SaveChanges();
                }
            }
        }
    }
}
