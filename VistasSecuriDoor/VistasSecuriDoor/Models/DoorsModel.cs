using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Models
{
    public class DoorsModel : BaseViewModel {

        [JsonProperty("door1")]
        public string DoorName { get; set; }

        [JsonProperty("location")]
        public string DoorLocation { get; set;}

        public bool DoorState { get; set; }

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
