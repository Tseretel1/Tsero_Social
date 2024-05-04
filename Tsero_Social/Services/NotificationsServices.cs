using System.Reflection;
using Tsero_Social.Dbcontext;
using Tsero_Social.InterFaces;
using Tsero_Social.Migrations;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public class NotificationsServices : INotification
    {
        private readonly UserDbcontext _dbcontext;
        public NotificationsServices(IWebHostEnvironment hostingEnvironment, UserDbcontext db)
        {
            _dbcontext = db;
        }

        public void AllNotificationDeletion(int CurrentuserID)
        {
            var IFNOtificationExists = _dbcontext.Notifications.Where(u=>u.ReceiverID == CurrentuserID);
            if(IFNOtificationExists !=null)
            {
                foreach(var item  in IFNOtificationExists)
                {
                    _dbcontext.Notifications.Remove(item);
                }
                _dbcontext.SaveChanges();
            }
        }

        public void Notification(int SenderID, int RecieverID, int Type)
        {
            var SenderLegit = _dbcontext.Users.SingleOrDefault(u=>u.id == SenderID);
            var RecieverLegit = _dbcontext.Users.SingleOrDefault(u => u.id == RecieverID);
            if(SenderLegit != null && RecieverLegit!=null)
            {
                var Follow = new Notificationss
                {
                    SenderID = SenderID,
                    ReceiverID = RecieverID,
                    NTF_DateTime = DateTime.Now,
                    NTF_Type = Type,
                    Seen = false,
                };
                _dbcontext.Notifications.Add(Follow);
                _dbcontext.SaveChanges();
            }
        }

        public void NotificationDelete(int NotificationID)
        {
           var IFNotificationExists = _dbcontext.Notifications.SingleOrDefault(u=> u.id == NotificationID);
           if(IFNotificationExists!= null)
            {
                _dbcontext.Notifications.Remove(IFNotificationExists);
                _dbcontext.SaveChanges();
            }
        }
    }
}
