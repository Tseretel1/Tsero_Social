using Tsero_Social.Dbcontext;
using Tsero_Social.InterFaces;
using Tsero_Social.Migrations;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class LikeCommentService : ILikeCommentService
    {
        private readonly UserDbcontext _dbcontext;
        private readonly NotificationsServices _notificationss;
        public LikeCommentService(IWebHostEnvironment hostingEnvironment, UserDbcontext db, NotificationsServices notificationss)
        {
           _dbcontext = db;
           _notificationss = notificationss;   
        }

        public void AddComment(int Postid, int currentUserID, string Comment)
        {
            if(Comment != null && Postid!=null && currentUserID!=null)
            {
                var NewComment = new Models.Comments()
                {
                    Comment = Comment,
                    UserID = currentUserID,
                    PostID = Postid,
                    DateTime = DateTime.Now,
                };
                _dbcontext.Comments.Add(NewComment);
                _dbcontext.SaveChanges();
            }
        }

        public void Comment_like(int CommentID, int UserID)
        {
            var IF_Comment_IS_Liked = _dbcontext.Com_Likes.FirstOrDefault(u => u.CommentID == CommentID && u.UserID == UserID);
            if (IF_Comment_IS_Liked != null)
            {
                _dbcontext.Com_Likes.Remove(IF_Comment_IS_Liked);
                _dbcontext.SaveChanges();
            }
            else
            {
                var Com_Like = new Com_Likes()
                {
                    CommentID = CommentID,
                    UserID = UserID
                };
                _dbcontext.Com_Likes.Add(Com_Like);
                _dbcontext.SaveChanges();
            }
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

                    int Notificationtype = 1;
                    var Postauthor = _dbcontext.Posts.FirstOrDefault(u => u.Id == Postid);
                    if (Postauthor != null && CurrentUserID!= Postauthor.UserID)
                    {
                        var Notification = new Notificationss()
                        {
                            User1 = CurrentUserID,
                            User2 = Postauthor.UserID,
                            Type = Notificationtype,
                            DateTime = DateTime.Now,

                        };
                        _notificationss.Notification(Notification);
                    }
                }
            }
        }
    }
}
