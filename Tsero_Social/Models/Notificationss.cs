namespace Tsero_Social.Models
{
    public class Notificationss
    {
        public int id  {   get; set;}
        public int SenderID { get; set; }
        public int ReceiverID { get; set;}
        public int NTF_Type { get; set; }
        public DateTime NTF_DateTime { get; set; }
        public bool Seen { get; set; }
    }
}
