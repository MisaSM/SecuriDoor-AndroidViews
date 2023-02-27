using System;
using System.Collections.Generic;
using System.Text;

namespace VistasSecuriDoor.Models
{
    public class UsersModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
