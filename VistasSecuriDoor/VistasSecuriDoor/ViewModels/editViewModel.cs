using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class editViewModel : BaseViewModel
    {
        public string guestEdit_Id;
        public string guestEdit_name;
        public string guestEdit_lastname;
        public string guestEdit_user;
        public string guestEdit_pwd;

        public UsersModel _user;

        public string guestEditId 
        {
            get { return guestEdit_Id; }
            set { SetProperty(ref guestEdit_Id, value ); }
        }

        public string guestEditName
        {
            get { return guestEdit_name; }
            set { SetProperty(ref guestEdit_name, value); }
        }

        public string guestEditLName
        {
            get { return guestEdit_lastname; }
            set { SetProperty(ref guestEdit_lastname, value); }
        }

        public string guestEditUser
        {
            get { return guestEdit_user; }
            set { SetProperty(ref guestEdit_user, value); }
        }

        public string guestEditPwd
        {
            get { return guestEdit_pwd; }
            set { SetProperty(ref guestEdit_pwd, value); }
        }

        public UsersModel User 
        {
            get { return _user; } 
            set { SetProperty(ref _user, value); }
        }


        public editViewModel(INavigation navigation, UsersModel user)
        {
            Navigation = navigation;
            User = user;
            guestEditId = User.Id;
            guestEditUser = User.userName;
            guestEditName = User.Name;
            guestEditLName = User.LastName;
            guestEditPwd = User.Password;
        }

        public ICommand EditUserCommand => new Command(async () =>
        {
            
            if (string.IsNullOrEmpty(guestEditName) || string.IsNullOrEmpty(guestEditLName) || string.IsNullOrEmpty(guestEditUser) || string.IsNullOrEmpty(guestEditPwd))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor llene todos los campos", "OK");
                return;
            }

            var editUser = new UsersModel
            {
                Id = guestEditId,
                Name = guestEditName,
                userName = guestEditUser,
                LastName = guestEditLName,
                Password = guestEditPwd
            };

            var client = new HttpClient();
            var contentJson = new StringContent(JsonConvert.SerializeObject(editUser), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://securidoor-web-api.onrender.com/api/guest/{guestEditId}", contentJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Application.Current.MainPage.DisplayAlert("", "Informacion de invitado editada correctamente", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al conectar a la base de datos", "OK");
                Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        });
    }
}
