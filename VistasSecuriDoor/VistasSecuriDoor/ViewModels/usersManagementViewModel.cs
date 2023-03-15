using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Data;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.Views;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class usersManagementViewModel : BaseViewModel {
        string _title = "Gestión de invitados";
        public ObservableCollection<UsersModel> _usersList;

        public usersManagementViewModel(INavigation navigation) {
            Navigation = navigation;
            ShowUsers();
        }

        public string Title { 
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        public ObservableCollection<UsersModel> Users {
            get { return _usersList; }
            set { SetProperty(ref _usersList, value); }
        }

        public async Task ShowUsers() {
            Users = await UsersData.ShowUsers();
            Users.ToList();
            foreach(UsersModel user in Users) 
            {
                Debug.WriteLine($"{user.Name} {user.userName} {user.Id}");
            }
        }   


    }
}
