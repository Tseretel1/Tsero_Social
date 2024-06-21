using System.ComponentModel.DataAnnotations.Schema;

namespace Tsero_Social.Models
{
    public class Notificationss
    {
        
        public int id  { get; set;}
        public int User1 { get; set; }
        public int User2 { get; set;}
        public int Type { get; set; }
        public DateTime DateTime { get; set; }
        public int userid { get; set; }
        public bool Seen { get; set; }
    }
}
