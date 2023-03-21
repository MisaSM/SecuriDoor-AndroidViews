using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
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
    public class PopupViewModel : BaseViewModel
    {
        public usersManagementViewModel _uservm;

        public string guest_name;
        public string guest_lastname;
        public string guest_user;
        public string guest_pwd;


        public string GuestName
        {
            get { return guest_name; }
            set { SetProperty(ref guest_name, value); }
        }

        public string GuestLName
        {
            get { return guest_lastname; }
            set { SetProperty(ref guest_lastname, value); }
        }

        public string GuestUser
        {
            get { return guest_user; }
            set { SetProperty(ref guest_user, value); }
        }

        public string GuestPwd
        {
            get { return guest_pwd; }
            set { SetProperty(ref guest_pwd, value); }
        }

        public PopupViewModel(INavigation navigation, usersManagementViewModel uservm)
        {
            Navigation = navigation;
            _uservm = uservm;
        }

        public async Task postData()
        {
            if (string.IsNullOrEmpty(GuestName) || string.IsNullOrEmpty(GuestLName) || string.IsNullOrEmpty(GuestUser) || string.IsNullOrEmpty(GuestPwd))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor llene todos los campos", "OK");
                return;
            }

            UsersModel user = new UsersModel
            {
                Name = GuestName,
                userName = GuestUser,
                LastName = guest_lastname,
                Password = GuestPwd,
                IdRol = new string[] { "640ee57c7027f674e8df3774" }
            };

            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(user);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://securidoor-web-api.onrender.com/api/guest", contentJson);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {


                    _uservm.IsLoading = true;
                    _uservm.SpinnerVisible = true;
                    await Task.Delay(2000);
                    _uservm.Users.Clear();
                    _uservm.Users = await UsersData.ShowUsers();
                    _uservm.IsLoading = false;
                    _uservm.SpinnerVisible = false;
                    await Application.Current.MainPage.DisplayAlert("", "Se dio de alta correctamente al invitado", "OK");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Fallo al conectar a la base de datos", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Network Error: {ex.Message}");
            }
        }


        public ICommand PostDataCommand => new Command(async () => await postData());


    }
}
