using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class usersManagementViewModel : BaseViewModel {
        string _title = "Control de usuarios";
        public ObservableCollection<UsersModel> _usersList { get; set; }

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
            set { _usersList = value; }
        }

        public async Task ShowUsers() {
           Users = await Data.UsersData.ShowUsers();
            Users.ToList();
            foreach(UsersModel user in Users) 
            {
                Debug.WriteLine($"Nombre: {user.Name}, Id: {user.Id}");
            }
            
        }

    }
}
