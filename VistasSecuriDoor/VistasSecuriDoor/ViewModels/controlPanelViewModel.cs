using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class controlPanelViewModel : BaseViewModel
    {
        #region Variables
        string _title = "Control de puertas";
        public ObservableCollection<DoorsModel> _doorsList { get; set; }
        public ObservableCollection<DoorGroupModel> _doorGroups { get; set; }
        #endregion
        #region Contructor
        public controlPanelViewModel(INavigation navigation) {
            Navigation = navigation;
            ShowGroups();
            ShowDoors();
        }
        #endregion
        #region Objetos
        public string Title { 
            get { return _title; }
            set { SetValue(ref _title, value); }
        }
        public ObservableCollection<DoorsModel> Doors {
            get { return _doorsList; }
            set { _doorsList = value; }
        }

        public ObservableCollection<DoorGroupModel> Groups 
        {
            get { return _doorGroups; }
            set  { _doorGroups = value;  }
        }



        #endregion
        #region Procesos
        public void ShowDoors() { 
            Doors = new ObservableCollection<DoorsModel>(Data.DoorsData.ShowDoors());
        }

        public void ShowGroups() 
        {
            Groups = new ObservableCollection<DoorGroupModel>(Data.DoorsData.ShowGroups());
        }


        public void updateState(DoorsModel model) {
            var index = _doorsList
                .ToList()
                .FindIndex(p => p.DoorName == model.DoorName);

            if (index > -1) {
                _doorsList[index].ButtonWasClicked = true;
            }

            if (_doorsList[index].DoorState == true) {
                _doorsList[index].BackgroundColor = "#FFFFFF";
            }
        }


        #endregion
        #region Commands
        public ICommand ButtonCmd => new Command<DoorsModel>((p) => updateState(p));
        #endregion
    }
}
