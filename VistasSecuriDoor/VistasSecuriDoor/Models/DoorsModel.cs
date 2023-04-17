using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VistasSecuriDoor.ViewModels;

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
