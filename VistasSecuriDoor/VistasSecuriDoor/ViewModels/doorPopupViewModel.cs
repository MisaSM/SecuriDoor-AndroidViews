using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class doorPopupViewModel : BaseViewModel
    {
        public DoorsModel _door;
        public int _doorProx;
        public string _doorId;

        public DoorsModel Door 
        {
            get { return _door; } 
            set { SetProperty(ref _door, value); }
        }

        public int DoorProx 
        {
            get { return _doorProx; }
            set { SetProperty(ref _doorProx, value); }
        }

        public doorPopupViewModel(INavigation navigation, DoorsModel door) 
        {
            Door = door;
            DoorProx = Door.door_proximity;
            Navigation = navigation;
        }

        public ICommand EditDoorCommand => new Command(async () =>
        {
            Debug.WriteLine($"{Door.DoorName} {Door.DoorId} {Door.door_proximity} {Door.DoorState}");
            if (DoorProx <= 0)
             {
              await App.Current.MainPage.DisplayAlert("Error", "Valor inválido para distancia, verifiquelo otra vez", "OK");
                DoorProx = 0;
                return;
              }
            if (DoorProx > 48)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Distancia no puede superar valores a 48", "OK");
                DoorProx = 48;
                return;
            }

            string token = Application.Current.Properties["token"] as string;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var contentJson = new StringContent(JsonConvert.SerializeObject(Door), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://securidoor-web-api.onrender.com/api/door/{Door.DoorId}", contentJson);

            var responseContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"Response status code: {response.StatusCode}");
            Debug.WriteLine($"Response content: {responseContent}");
            Debug.WriteLine(await contentJson.ReadAsStringAsync());

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Distancia editada correctamente!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al conectar a la base de datos", "OK");
                Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        });

        }
        }

