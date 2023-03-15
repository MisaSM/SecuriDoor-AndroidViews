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
        public ObservableCollection<NotificationsModel> _lastNotifs;

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
        public ObservableCollection<NotificationsModel> lastNotifs
        {
            get { return _lastNotifs; }
            set { SetProperty(ref _lastNotifs, value); }
        }

        public void ShowNotification()
        {
            notificationsList = Data.NotificationsData.ShowNotification();
            lastNotifs = new ObservableCollection<NotificationsModel>(notificationsList.Skip(Math.Max(0, notificationsList.Count - 5)));
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
