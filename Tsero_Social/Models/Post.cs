using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsero_Social.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? post { get; set; }
        public string? Photo { get; set; }  
        public int UserID { get; set; }
        public DateTime DateTime { get; set; }
        public int? PostType { get;set; }
    }
}
