using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VistasSecuriDoor.Models
{
    public class UsersModel {
        
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("guest_name")]
        public string Name { get; set; }

        [JsonProperty("guest_lastName")]
        public string LastName { get; set; }

        [JsonProperty("guest_user")]
        public string userName { get; set; }

        [JsonProperty("guest_pwd")]
        public string Password { get; set; }
        
        [JsonProperty("owner_id")]
        public string IdRol { get; set; }
    }
}
