namespace Tsero_Social.Models
{
    public class User
    {
        public int id { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string? ProfilePicture { get; set; }  
        public string? ProfilePath { get; set; }
        public bool Isonline { get; set; }

        public static List<User> Loged_user = new List<User>();
    }
}
