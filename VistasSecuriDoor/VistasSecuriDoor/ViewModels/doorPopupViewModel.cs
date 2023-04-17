using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Data;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class doorPopupViewModel : BaseViewModel
    {
        public controlPanelViewModel _cpVM;

        public bool _imgPopup;

        public string _editDoorName;
        public string _editDoorLocation;
        public int _editDoorProx;
        public string _editDoorId;
        public string _doorRoomId;
        public string _doorStatus;

        public int EditDoorProx 
        {
            get { return _editDoorProx; }
            set { SetProperty(ref _editDoorProx, value); }
        }

        public bool SuccessPopup 
        {
            get { return _imgPopup; }
            set { SetProperty(ref _imgPopup, value); }
        }

        public string EditDoorName 
        {
            get { return _editDoorName; }
            set { SetProperty(ref _editDoorName, value); }
        }

        public string EditDoorLocation 
        {
            get { return _editDoorLocation; }
            set { SetProperty(ref _editDoorLocation, value); }
        }

        public string EditDoorId 
        {
            get { return _editDoorId; }
            set
            {
                SetProperty(ref _editDoorId, value);
            }
        }

        public string EditDoorRoomId 
        {
            get { return _doorRoomId; }
            set { SetProperty(ref _doorRoomId, value); }
        }

        public string EditDoorState 
        {
            get { return _doorStatus; }
            set { SetProperty(ref _doorStatus, value); }
        }

        public doorPopupViewModel(INavigation Navigation, DoorsModel Door, controlPanelViewModel cpVM)
        {
            EditDoorName = Door.DoorName;
            EditDoorId = Door.DoorId;
            EditDoorProx = Door.door_proximity;
            EditDoorRoomId = Door.DoorLocation;
            EditDoorState = Door.DoorState;
            _cpVM = cpVM;
        }

        public ICommand EditDoorCommand => new Command(async () =>
        {
            if (EditDoorProx <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Valor inválido para distancia, verifiquelo otra vez", "OK");
                return;
            }
            if (EditDoorProx > 48)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Distancia no puede superar valores a 48", "OK");
                EditDoorProx = 48;
                return;
            }

            var editDoor = new DoorsModel
            {
                DoorId = EditDoorId,
                DoorName = EditDoorName,
                DoorState = EditDoorState,
                DoorLocation = EditDoorRoomId,
                door_proximity = EditDoorProx,
            };

            var client = new HttpClient();
            var contentJson = new StringContent(JsonConvert.SerializeObject(editDoor), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://securidoor-web-api.onrender.com/api/door/{EditDoorId}", contentJson);

            var responseContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"Response status code: {response.StatusCode}");
            Debug.WriteLine($"Response content: {responseContent}");
            Debug.WriteLine(await contentJson.ReadAsStringAsync());
            if (response.StatusCode == HttpStatusCode.OK)
            {
               
               
                _cpVM.Doors.Clear();
                _cpVM.IsLoading = true;
                _cpVM.SpinnerVisible = true;
                await Task.Delay(2000);
                _cpVM.Doors = await DoorsData.ShowDoors();
                _cpVM.IsLoading = false;
                _cpVM.SpinnerVisible = false;
            }
            else
            {
                //show the success image
                SuccessPopup = true;

                // Wait for another 2 seconds
                await Task.Delay(2000);

                // Hide the success popup
                SuccessPopup = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Fallo al conectar a la base de datos", "OK");
                Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
            }

        });


    }
}
