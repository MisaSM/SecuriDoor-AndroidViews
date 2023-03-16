using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class PopupViewModel : BaseViewModel
    {
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
            set { SetProperty(ref guest_pwd, value);}
        }

        public PopupViewModel(INavigation navigation) 
        {
            Navigation = navigation;
        }

        public async Task postData()
        {
            UsersModel user = new UsersModel
            {
                Name = GuestName,
                userName = GuestUser,
                LastName= guest_lastname,
                Password = GuestPwd,
                IdRol = new string[] { "640ee57c7027f674e8df3774" }
            };

            try
            {
                Uri RequestUri = new Uri("https://securidoor-web-api.onrender.com/api/guest");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(user);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var jsonString = await contentJson.ReadAsStringAsync();
                Debug.WriteLine(jsonString);
                var response = await client.PostAsync(RequestUri, contentJson);
                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Debug.WriteLine($"Respuesta: {response.StatusCode}");
                    await Application.Current.MainPage.DisplayAlert("", "Se dio de alta correctamente al invitado", "OK");
                }
                else
                {
                    Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
                    Debug.WriteLine($"Respuesta: {response.StatusCode}");
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
