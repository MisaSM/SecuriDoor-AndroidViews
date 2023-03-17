using System;
using System.Collections.Generic;
using System.Text;

namespace VistasSecuriDoor.Models
{
    public class OwnerModel
    {
        public string _id { get; set; }
        public string owner_name { get; set; }
        
        public string owner_lastName { get; set; }

        public string owner_user { get; set; }

        public string owner_email { get; set; }

        public string owner_pwd { get; set; }
    }
}
