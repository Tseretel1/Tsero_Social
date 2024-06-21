using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsero_Social.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
    }
}
