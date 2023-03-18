using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine($"{guestEditName} {guestEditUser} {guestEditId}");
            Uri RequestUri = new Uri($"https://securidoor-web-api.onrender.com/api/guest/{guestEditId}");
            var client = new HttpClient();
            if (string.IsNullOrEmpty(guestEditName) || string.IsNullOrEmpty(guestEditLName) || string.IsNullOrEmpty(guestEditUser) || string.IsNullOrEmpty(guestEditPwd))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor llene todos los campos", "OK");
                return;
            }

            UsersModel editUser = new UsersModel
            {
                Id = guestEditId,
                Name = guestEditName,
                userName = guestEditUser,
                LastName = guestEditLName,
                Password = guestEditPwd
            };

            var json = JsonConvert.SerializeObject(editUser);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var jsonString = await contentJson.ReadAsStringAsync();

            Debug.WriteLine($"{editUser.Name} {editUser.userName}");
        
            
            var response = await client.PutAsync(RequestUri, contentJson);

            Debug.WriteLine(await contentJson.ReadAsStringAsync());
            Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Debug.WriteLine($"Respuesta: {response.StatusCode}");
                await Application.Current.MainPage.DisplayAlert("", "Informacion de invitado editada correctamente", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al conectar a la base de datos", "OK");
                Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
                Debug.WriteLine($"Respuesta: {response.StatusCode}");
            }

        });
    }
}
