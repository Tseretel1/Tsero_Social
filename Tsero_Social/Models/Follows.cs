using System.ComponentModel.DataAnnotations.Schema;

namespace Tsero_Social.Models
{
    public class Follows
    {
        public int id { get; set; }
        public int User1 { get; set; }
        public int User2 { get; set; }
    }
}
