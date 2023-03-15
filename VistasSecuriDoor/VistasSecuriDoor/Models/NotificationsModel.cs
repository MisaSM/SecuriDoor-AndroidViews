using System;
using System.Collections.Generic;
using System.Text;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Models
{
    public class NotificationsModel : BaseViewModel {
        public int NotificationId { get; set; }
        public string NotificationTitle { get; set; }
        public string Notification { get; set; }
        public DateTime DateNotification { get; set; }
        public string NotificationType { get; set; }
    }
}
