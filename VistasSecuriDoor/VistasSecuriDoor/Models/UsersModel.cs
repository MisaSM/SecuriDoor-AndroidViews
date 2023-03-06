using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VistasSecuriDoor.Models
{
    public class UsersModel {
        [JsonProperty("idUser")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Name { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
