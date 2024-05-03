namespace Tsero_Social.InterFaces
{
    public interface INotification
    {
        void Notification(int SenderID, int RecieverID,int Type);
        void NotificationDelete(int NotificationID);
    }
}
