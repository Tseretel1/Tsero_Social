namespace Tsero_Social.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string post { get; set; }
        public string Photo { get; set; }
        public int UserID { get; set; }
        public DateTime DateTime { get; set; }
    }
}
