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
                OnPropertyChanged(nameof(IsOwner));
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


                var authClient = new HttpClient();

                //Provee el token y el bearer
                authClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //Debug.WriteLine($"Token preservado? {token}");
                var authRequestData = await authClient.GetAsync("https://securidoor-web-api.onrender.com/api/isOwner");
                var responseObject = await authRequestData.Content.ReadAsStringAsync();

                if (authRequestData.IsSuccessStatusCode)
                {
                    var testing = JsonConvert.DeserializeObject<authRequest>(responseObject);

                    IsOwner = testing.isOwner;


                    MessagingCenter.Send(this, "IsOwner?", testing.isOwner);
                    MessagingCenter.Send(this, "messageStatus", $"Bienvenido {currentUserName}!");

                    Debug.WriteLine($"Es owner? {IsOwner}");
                }
                else
                {
                    IsOwner = false;
                    MessagingCenter.Send(this, "IsOwner?", false);
                    MessagingCenter.Send(this, "messageStatus", $"Bienvenido {currentUserName}!");
                    //Debug.WriteLine(otherVM.UserAuth);
                    Debug.WriteLine($"Es owner? {IsOwner}");
                }

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


       


    }

    }

