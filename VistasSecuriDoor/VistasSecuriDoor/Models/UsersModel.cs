using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VistasSecuriDoor.Models
{
    public class UsersModel {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("owner_name")]
        public string Name { get; set; }

        [JsonProperty("owner_user")]
        public string userName { get; set; }

        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
