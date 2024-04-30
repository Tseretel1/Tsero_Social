namespace Tsero_Social.Models
{
    public class Notifications
    {
        public int id  {   get; set;}
        public int SenderID { get; set; }
        public int ReceiverID { get; set;}
        public int NTF_Type { get; set; }
        public string NotifyMessage { get; set; }
        public bool Seen { get; set; }
    }
}
