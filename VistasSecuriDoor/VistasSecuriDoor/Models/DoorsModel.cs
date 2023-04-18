using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using VistasSecuriDoor.ViewModels;
using VistasSecuriDoor.Views;
using Xamarin.Forms;

namespace VistasSecuriDoor.Models
{
    public class DoorsModel : BaseViewModel {

        [JsonProperty("_id")]
        public string DoorId { get; set; }

        [JsonProperty("door_name")]
        public string DoorName { get; set; }


        [JsonProperty("door_status")]
        public string DoorState { get; set; }

        public int door_proximity { get; set; }


        public string _backgroundColor;
        public bool _buttonWasClicked;

        public string BackgroundColor {
            get { return _backgroundColor; }
            set { SetProperty(ref _backgroundColor, value); }
        }
        public bool ButtonWasClicked {
            get { return _buttonWasClicked; }
            set { SetProperty(ref _buttonWasClicked, value); }
        }

        public class RoomsModel : BaseViewModel
        {

            [JsonProperty("room_name")]
            public string Name { get; set; }


            [JsonProperty("room_id")]
            public string DoorLocation { get; set; }

            public ObservableCollection<DoorsModel> doors { get; set; }


            public ICommand EditDoorProx => new Command<DoorsModel>(async (doorToEdit) =>
            {
                if (doorToEdit != null)
                {
                    await PopupNavigation.Instance.PushAsync(new doorPopup(doorToEdit));
                }
            });

            public ICommand ChangeDoorStatus => new Command<DoorsModel>(async (doorToOpen) =>
            {
                if (doorToOpen != null)
                {
                    doorToOpen.DoorState = doorToOpen.DoorState == "abierto" ? "cerrado" : "abierto";
                    doorToOpen.BackgroundColor = doorToOpen.BackgroundColor == "red" ? "green" : "red";
                }


                string token = Application.Current.Properties["token"] as string;

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var contentJson = new StringContent(JsonConvert.SerializeObject(doorToOpen), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"https://securidoor-web-api.onrender.com/api/door/{doorToOpen.DoorId}/status", contentJson);

                var responseContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(response.StatusCode);
                Debug.WriteLine(responseContent);

            });


        }

        public class PlaceModel : BaseViewModel 
        {
            public string _id { get; set; }

            [JsonProperty("place_name")]
            public string PlaceName { get; set; }
            public string owner_id { get; set; }
            
            public ObservableCollection<RoomsModel> rooms { get; set; }
        }

    }
}
