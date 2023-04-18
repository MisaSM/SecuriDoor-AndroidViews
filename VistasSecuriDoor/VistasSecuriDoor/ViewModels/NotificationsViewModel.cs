 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Data;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class NotificationsViewModel : BaseViewModel
    {

        public ObservableCollection<NotificationsModel> _notificationsList;
        bool _isLoading = false;
        bool _spinnerVisible = false;
        public string _title { get; set; }


        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public bool SpinnerVisible
        {
            get { return _spinnerVisible; }
            set
            {
                if (_spinnerVisible != value)
                {
                    _spinnerVisible = value;
                    OnPropertyChanged(nameof(SpinnerVisible));
                }
            }
        }
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

        public ObservableCollection<NotificationsModel> Photos
        {
            get { return _notificationsList; }
            set { SetProperty(ref _notificationsList, value); }
        }


        public async void ShowNotification()
        {
            IsLoading = true;
            SpinnerVisible = true;
            await Task.Delay(2000);
            Photos = await NotificationsData.ShowNotification();
            IsLoading = false;
            SpinnerVisible = false;
        }

        public ICommand UpdateView => new Command(async () =>
        {
            Photos.Clear();
            ShowNotification();
        });

        public ICommand DeleteCommand => new Command<NotificationsModel>( async (PhotoToDelete) =>
        {
            bool shouldDelete = await Application.Current.MainPage.DisplayAlert("Advertencia", "Esta acción no se puede revertir", "OK", "Cancelar");

            if (shouldDelete)
            {
                if (PhotoToDelete != null)
                {
                    var client = new HttpClient();
                    var response = await client.DeleteAsync($"https://securidoor-web-api.onrender.com/api/photo/{PhotoToDelete.id}");
                    Photos.Remove(PhotoToDelete);
                }
                
            }

        });
    }
}
