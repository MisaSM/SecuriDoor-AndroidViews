using System;
using System.Collections.Generic;
using System.Text;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Models
{
    public class DoorsModel : BaseViewModel
    {
        public string DoorName { get; set; }
        public string DoorLocation { get; set;}
        public bool DoorState { get; set; }
    }
}
