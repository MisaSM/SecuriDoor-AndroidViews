﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VistasSecuriDoor.Models
{
    public class UsersModel {
        //change the properties to the according BD model dammit!!!!
        //[JsonProperty("_id")]
        //public string Id { get; set; }

        [JsonProperty("guest_name")]
        public string Name { get; set; }

        [JsonProperty("guest_user")]
        public string userName { get; set; }

        public string Password { get; set; }
        
        [JsonProperty("owner_id")]
        public string[] IdRol { get; set; }
    }
}
