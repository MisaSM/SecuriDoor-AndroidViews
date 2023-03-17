 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class NotificationsViewModel : BaseViewModel
    {

        public ObservableCollection<NotificationsModel> _notificationsList;

        public string _title { get; set; }

        public NotificationsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ShowNotification();
            Title = "Notificaciones";
        }

        public string Title 
        {
            get { return _title; }
            set { _title = value; }
        }

        public ObservableCollection<NotificationsModel> notificationsList
        {
            get { return _notificationsList; }
            set { SetProperty(ref _notificationsList, value); }
        }


        public void ShowNotification()
        {
            notificationsList = Data.NotificationsData.ShowNotification();
        }

        public ICommand DeleteCommand => new Command<int>((notificationId) => 
        {
            var notifToRemove = notificationsList.FirstOrDefault(n => n.NotificationId == notificationId);
            if (notifToRemove != null) 
            {
                notificationsList.Remove(notifToRemove);
            }
        });

    }
}
