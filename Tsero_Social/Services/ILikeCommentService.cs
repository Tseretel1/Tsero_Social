using Microsoft.EntityFrameworkCore;

namespace Tsero_Social.Services
{
    public interface ILikeCommentService
    {
        void PostToLike(int Postid, int CurrentUserID);
        int GetLikeCount(int postId);
        bool IsPostLikedByUser(int postId, int userId);
      
    }
}
