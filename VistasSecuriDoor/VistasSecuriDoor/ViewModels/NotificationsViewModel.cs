using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class NotificationsViewModel : BaseViewModel
    {

        public NotificationsModel _lastNotification { get; set; }

        public ObservableCollection<NotificationsModel> _notificationsList { get; set; }


        public NotificationsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ShowNotification();
        }

        public NotificationsModel lastNotification
        {
            get { return _lastNotification; }
            set { _lastNotification = value; }
        }

        public ObservableCollection<NotificationsModel> notificationsList
        {
            get { return _notificationsList; }
            set { _notificationsList = value; }
        }

        public void ShowNotification()
        {
            notificationsList = new ObservableCollection<NotificationsModel>(Data.NotificationsData.ShowNotification());
            lastNotification = notificationsList.LastOrDefault();
        }




    }
}
