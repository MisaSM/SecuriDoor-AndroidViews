using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Data;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.Views;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class usersManagementViewModel : BaseViewModel, INotifyPropertyChanged
    {
        string _title = "Gestión de invitados";
        bool _isLoading = false;
        bool _spinnerVisible = false;
        ObservableCollection<UsersModel> _usersList;

        public usersManagementViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ShowUsers();
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

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

        public ObservableCollection<UsersModel> Users
        {
            get { return _usersList; }
            set
            {
                if (_usersList != value)
                {
                    _usersList = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        public async Task ShowUsers()
        {
            IsLoading = true;
            SpinnerVisible = true;
            await Task.Delay(2000);
            Users = await UsersData.ShowUsers();
            IsLoading = false;
            SpinnerVisible = false;
        }

        public ICommand DeleteUserCommand => new Command<string>(async (userId) =>
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Advertencia", "Esta acción no puede ser revertida", "OK", "Cancelar");
            
            if (answer == true) 
            {
                var userToDelete = Users.FirstOrDefault(n => n.Id == userId);
                if (userToDelete != null)
                {
                    Debug.WriteLine(userToDelete.Id, userToDelete.Name);
                    Uri RequestUri = new Uri($"https://securidoor-web-api.onrender.com/api/guest/{userToDelete.Id}");
                    var client = new HttpClient();
                    var response = await client.DeleteAsync(RequestUri);
                    Users.Remove(userToDelete);
                    Debug.WriteLine(response.StatusCode);
                }
            } else if (answer == false) 
            {
                return;
            }
            
        });

        public ICommand EditUserCommand => new Command<string>(async (userId) => 
        {
            var userToEdit = Users.FirstOrDefault(n => n.Id == userId);
            if (userToEdit != null) 
            {
                var editViewModel = new editViewModel(Navigation, userToEdit);
                await PopupNavigation.PushAsync(new editGuestPopup() { BindingContext = editViewModel });
            }
        });

        public ICommand ShowPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new guestsPopup());
        });

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
