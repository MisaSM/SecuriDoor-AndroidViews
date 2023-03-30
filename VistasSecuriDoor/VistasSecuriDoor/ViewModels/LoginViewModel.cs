using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
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


        public bool _isOwner;
        

        public bool IsOwner
        {
            get { return _isOwner; }
            set
            {
                SetProperty(ref _isOwner, value);
                //OnPropertyChanged(nameof(IsOwner);
            }

        }


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
            LoginCommand = new Command(onLoginClicked);
            //IsLoggedIn();
        }

        public async void onLoginClicked()
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

            Debug.WriteLine(responseContent);


            //Debug.WriteLine(responseContent);



            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var tokenjson = JObject.Parse(responseContent);

                var token = tokenjson["token"].ToString();


                Application.Current.Properties["token"] = token;

                await Application.Current.SavePropertiesAsync();

                Debug.WriteLine(Application.Current.Properties["token"]);


                IsLoggedIn();

                Task.Delay(10000);

                await Shell.Current.GoToAsync($"//{nameof(dashboardPage)}");

                currentUserName = string.Empty;
                currentPassword = string.Empty;
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


        public async void IsLoggedIn()
        {
            // Debug.WriteLine(Application.Current.Properties.ContainsKey("token"));

            //crea variable local token a partir del token almacenado en cache, tal vez se pueda refactorizar
            string token = Application.Current.Properties["token"] as string;

            // Debug.WriteLine($"Token adquirido! {token}");
            var client = new HttpClient();

            //Provee el token y el bearer
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //Debug.WriteLine($"Token preservado? {token}");
            var authRequestData = await client.GetAsync("https://securidoor-web-api.onrender.com/api/isOwner");
            var responseObject = await authRequestData.Content.ReadAsStringAsync();
            //responseObject retorna el valor de isOwner además del 200 o Unauthorized access


            Debug.WriteLine(responseObject);

            if (authRequestData.IsSuccessStatusCode)
            {
                var testing = JsonConvert.DeserializeObject<authRequest>(responseObject);
                
                //Crea la llave "isOwner" y le asigna el valor retornado por el responseObject, este será true o false.
                Application.Current.Properties["isOwner"] = testing.isOwner;
                await Application.Current.SavePropertiesAsync();
                Debug.WriteLine($"Es owner? {Application.Current.Properties["isOwner"]}");

            }
            else
            {
                var testing = JsonConvert.DeserializeObject<authRequest>(responseObject);
                Application.Current.Properties["isOwner"] = testing.isOwner;
                await Application.Current.SavePropertiesAsync();
                Debug.WriteLine($"Es owner? {Application.Current.Properties["isOwner"]}");
            }


        }


    }

    }

