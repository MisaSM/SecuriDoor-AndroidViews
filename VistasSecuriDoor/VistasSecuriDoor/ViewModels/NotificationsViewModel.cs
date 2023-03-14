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

        public ObservableCollection<NotificationsModel> _notificationsList;
        public ObservableCollection<NotificationsModel> _lastNotifs;


        public NotificationsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ShowNotification();
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


    }
}
