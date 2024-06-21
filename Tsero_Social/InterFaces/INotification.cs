using Tsero_Social.Models;

namespace Tsero_Social.InterFaces
{
    public interface INotification
    {
        void Notification(Notificationss Notification);
        void NotificationDelete(int NotificationID);
        void AllNotificationDeletion(int CurrentuserID);
    }
}
