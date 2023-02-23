using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class controlPanelViewModel : BaseViewModel
    {
        #region Variables
        public ObservableCollection<DoorsModel> _doorsList { get; set; }
        #endregion
        #region Contructor
        public controlPanelViewModel(INavigation navigation) {
            Navigation = navigation;
            ShowDoors();
        }
        #endregion
        #region Objetos
        public ObservableCollection<DoorsModel> Doors
        {
            get { return _doorsList; }
            set { _doorsList = value; }
        }
        #endregion
        #region Procesos
        public void ShowDoors() { 
            Doors = new ObservableCollection<DoorsModel>(Data.DoorsData.ShowDoors());
        }
        #endregion
    }
}
