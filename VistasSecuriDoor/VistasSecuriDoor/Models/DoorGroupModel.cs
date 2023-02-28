using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Models
{
    public class DoorGroupModel : BaseViewModel
    {
        public string Location { get; set; }
        public ObservableCollection<DoorsModel> GroupedDoors { get; set; }
    }
}
