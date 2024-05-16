namespace Tsero_Social.Models
{
    public class Comments
    {
        public int id { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
    }
}
