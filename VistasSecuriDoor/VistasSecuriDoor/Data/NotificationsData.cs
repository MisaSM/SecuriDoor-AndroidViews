using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Data
{
    public class NotificationsData
    {
        public static ObservableCollection<NotificationsModel> ShowNotification()
        {
            return new ObservableCollection<NotificationsModel>()
            {
                new NotificationsModel()
                {
                    NotificationTitle = "Oficina",
                    Notification = "Se detectó un indicio de forcejeo",
                    DateNotification = DateTime.Now,
                    NotificationType = "https://i.ibb.co/DDHdc3z/26a0.png"
                }
            };
        }
    }
}
