using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VistasSecuriDoor.ViewModels;
using Xamarin.Forms;

namespace VistasSecuriDoor.Models
{
    public class DoorGroupModel : BaseViewModel
    {
        [JsonProperty("place_name")]
        public string Location { get; set; }

        [JsonProperty("rooms")]
        public string LocationId { get; set; }

        public ObservableCollection<DoorsModel> GroupedDoors { get; set; }   
        
    }
}
