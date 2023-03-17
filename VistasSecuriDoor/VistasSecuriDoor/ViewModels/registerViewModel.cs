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
    public class registerViewModel : BaseViewModel
    {

        public string owner_name;
        public string owner_lastname;
        public string owner_user;
        public string owner_email;
        public string owner_pwd;
        

        public string OwnerName
        {
            get { return owner_name; }
            set { SetProperty(ref owner_name, value); }
        }

        public string OwnerLName
        {
            get { return owner_lastname; }
            set { SetProperty(ref owner_lastname, value); }
        }

        public string OwnerUser
        {
            get { return owner_user; }
            set { SetProperty(ref owner_user, value); }
        }

        public string OwnerEmail
        {
            get { return owner_email; }
            set { SetProperty(ref owner_email, value); }
        }

        public string OwnerPwd
        {
            get { return owner_pwd; }
            set { SetProperty(ref owner_pwd, value); }
        }


        public registerViewModel(INavigation navigation) 
        {
            Navigation = navigation;
        }


        public async Task postOwnerData()
        {
            OwnerModel owner = new OwnerModel
            {
                owner_name = OwnerName,
                owner_user = OwnerUser,
                owner_lastName = OwnerLName,
                owner_email = OwnerEmail,
                owner_pwd = OwnerPwd,
            };

            try
            {
                Uri RequestUri = new Uri("https://securidoor-web-api.onrender.com/api/owner");
                var client = new HttpClient();
                if (string.IsNullOrEmpty(OwnerName) || string.IsNullOrEmpty(OwnerLName) || string.IsNullOrEmpty(OwnerUser) || string.IsNullOrEmpty(OwnerPwd))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Por favor llene todos los campos", "OK");
                    return;
                }
                var json = JsonConvert.SerializeObject(owner);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var jsonString = await contentJson.ReadAsStringAsync();
                Debug.WriteLine(jsonString);
                var response = await client.PostAsync(RequestUri, contentJson);
                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Debug.WriteLine($"Respuesta: {response.StatusCode}");
                    await Application.Current.MainPage.DisplayAlert("Alerta", "Cuenta creada exitosamente", "OK");
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



        public ICommand PostOwnerCommand => new Command(async () =>
        {
            await postOwnerData();
            await Shell.Current.GoToAsync("//LoginPage");
            OwnerName = "";
            OwnerLName = "";
            OwnerUser = "";
            OwnerEmail = "";
            OwnerPwd = "";
        });

        public ICommand ReturnToLoginCommand => new Command(async () => 
        {
            await Shell.Current.GoToAsync("//LoginPage");
        });

    }
}
