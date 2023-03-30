using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Models
{
    public class DoorsModel : BaseViewModel {

        [JsonProperty("_id")]
        public string DoorId { get; set; }

        [JsonProperty("door_name")]
        public string DoorName { get; set; }

        [JsonProperty("room_id")]
        public string DoorLocation { get; set;}

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

    }
}
