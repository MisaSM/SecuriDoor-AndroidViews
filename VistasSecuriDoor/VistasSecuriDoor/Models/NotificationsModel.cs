using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Models
{
    public class NotificationsModel : BaseViewModel {
        [JsonProperty("_id")]
        public string id { get; set; }

        [JsonProperty("photo_img")]
        public string img { get; set; }

        [JsonProperty("door_id")]
        public string doorId { get; set; }

        [JsonProperty("photo_date")]
        public DateTime photodate { get; set; }
    }
}
