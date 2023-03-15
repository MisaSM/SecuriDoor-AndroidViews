using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                    NotificationId = 1,
                    NotificationTitle = "Oficina",
                    Notification = "Se detectó un indicio de forcejeo",
                    DateNotification = DateTime.Now,
                    NotificationType = "https://i.ibb.co/DDHdc3z/26a0.png"
                },
                new NotificationsModel()
                {
                    NotificationId = 2,
                    NotificationTitle = "Escuela",
                    Notification = "Se detectó una entrada forzada",
                    DateNotification = DateTime.Parse("2/1/2023"),
                    NotificationType = "https://i.ibb.co/DDHdc3z/26a0.png"
                },
                new NotificationsModel()
                {
                    NotificationId = 3,
                    NotificationTitle = "Hola",
                    Notification = "Se detectó un indicio de forcejeo",
                    DateNotification = DateTime.Now,
                    NotificationType = "https://i.ibb.co/DDHdc3z/26a0.png"
                },
                new NotificationsModel()
                {
                    NotificationId = 4,
                    NotificationTitle = "Adios",
                    Notification = "Se detectó una entrada forzada",
                    DateNotification = DateTime.Parse("2/1/2023"),
                    NotificationType = "https://i.ibb.co/DDHdc3z/26a0.png"
                },
                new NotificationsModel()
                {
                    NotificationId = 5,
                    NotificationTitle = "Golpe",
                    Notification = "Se detectó una entrada forzada",
                    DateNotification = DateTime.Parse("2/1/2023"),
                    NotificationType = "https://i.ibb.co/DDHdc3z/26a0.png"
                },
                new NotificationsModel()
                {
                    NotificationId = 6,
                    NotificationTitle = "Golpe 2!",
                    Notification = "Se detectó una entrada forzada",
                    DateNotification = DateTime.Parse("2/1/2023"),
                    NotificationType = "https://i.ibb.co/DDHdc3z/26a0.png"
                }
            };
        }


    }
}
