using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public class LoginViewModel : BaseViewModel
    {
        public string _currentuserName;
        public string _currentpassword;

        public string currentUserName
        {
            get { return _currentuserName; }
            set { SetProperty(ref _currentuserName, value); }
        }

        public string currentPassword 
        {
            get { return _currentpassword; }
            set { SetProperty(ref _currentpassword, value); }
        }


        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
           
        }

        private async void OnLoginClicked(object obj)
        {
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(currentUserName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor llene todos los campos", "OK");
                return;
            }


            var client = new HttpClient();

            loginRequest req = new loginRequest
            {
                user = currentUserName,
                password = currentPassword,
            };

            var data = JsonConvert.SerializeObject(req);

            var contentJson = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://securidoor-web-api.onrender.com/api/login", contentJson);


            var responseContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"{req.user} {req.password}");
            Debug.WriteLine($"Response status code: {response.StatusCode}");
            Debug.WriteLine($"Response content: {responseContent}");


            if (response.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                await Shell.Current.GoToAsync($"//{nameof(dashboardPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al conectar a la base de datos", "OK");
            }


        }

        public ICommand RegisterCommand => new Command(async () => 
        {
            await Shell.Current.GoToAsync("//registerOwner");
        });

    }
}
