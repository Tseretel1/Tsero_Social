using Microsoft.EntityFrameworkCore;

namespace Tsero_Social.InterFaces
{
    public interface ILikeCommentService
    {
        void PostToLike(int Postid, int CurrentUserID);
        int GetLikeCount(int postId);
        bool IsPostLikedByUser(int postId, int userId);
        void AddComment(int Postid, int currentUserID,string Comment);
    }
}
