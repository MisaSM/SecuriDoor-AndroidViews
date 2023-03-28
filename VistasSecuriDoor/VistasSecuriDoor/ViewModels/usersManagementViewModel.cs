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
            set { SetProperty(ref _usersList, value); }
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
            bool shouldDelete = await Application.Current.MainPage.DisplayAlert("Advertencia", "Esta acción no se puede revertir", "OK", "Cancelar");

            if (shouldDelete)
            {
                var userToDelete = Users.FirstOrDefault(n => n.Id == userId);
                if (userToDelete != null)
                {
                    var client = new HttpClient();
                    var response = await client.DeleteAsync($"https://securidoor-web-api.onrender.com/api/guest/{userToDelete.Id}");
                    Users.Remove(userToDelete);
                }
            }
        });

        public ICommand EditUserCommand => new Command<string>(async (userId) => 
        {
            var userToEdit = Users.FirstOrDefault(n => n.Id == userId);
            if (userToEdit != null) 
            {
                var editViewModel = new editViewModel(Navigation, userToEdit, this);
                await PopupNavigation.Instance.PushAsync(new editGuestPopup(this) { BindingContext = editViewModel });
            }
        });

        public ICommand ShowPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new guestsPopup(this));
        });

    }
}
