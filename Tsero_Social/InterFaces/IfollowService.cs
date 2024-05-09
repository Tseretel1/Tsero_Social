namespace Tsero_Social.InterFaces
{
    public interface IfollowService
    {
        void Follow(int FollowerID, int FollowingID);
        void RemoveFollower(int UserToRmoveID, int MyID);
        void RemoveFollowing(int FollowingToDelete, int MyID);
    }
}
