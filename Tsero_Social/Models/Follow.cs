namespace Tsero_Social.Models
{
    public class Follow
    {
        public int id { get; set; }
        public int FollowerID { get; set; }
        public int FollowingID { get; set; }
    }
}
