using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.Views;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class controlPanelViewModel : BaseViewModel
    {
        #region Variables
        string _title = "Control de puertas";
        bool _isLoading = false;
        bool _spinnerVisible = false;
        public ObservableCollection<DoorsModel> _doorsList;
        public ObservableCollection<DoorGroupModel> _doorGroups;

        public controlPanelViewModel _cpVM;
        #endregion
        #region Contructor
        public controlPanelViewModel(INavigation navigation) { 
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
            set { SetProperty(ref _doorsList, value); }
        }

        public ObservableCollection<DoorGroupModel> Groups 
        {
            get { return _doorGroups; }
            set  { SetProperty(ref _doorGroups, value); }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public bool SpinnerVisible
        {
            get { return _spinnerVisible; }
            set { SetProperty(ref _spinnerVisible, value); }
        }


        #endregion
        #region Procesos
        public async Task ShowDoors() {
            IsLoading = true;
            SpinnerVisible = true;

            await Task.Delay(2000);
            Doors = await Data.DoorsData.ShowDoors();
            IsLoading = false;
            SpinnerVisible = false;


        }

        //public async Task ShowGroups() 
        //{
        //    IsLoading = true;
        //    SpinnerVisible = true;

        //    await Task.Delay(2000);
        //    //Doors = await Data.DoorsData.ShowDoors();
        //    IsLoading = false;
        //    SpinnerVisible = false;
        //}




        public void updateState(DoorsModel model) {
            var index = _doorsList
                .ToList()
                .FindIndex(p => p.DoorName == model.DoorName);

            if (index > -1) {
                _doorsList[index].ButtonWasClicked = true;
            }

            if (_doorsList[index].DoorState == "abierto") {
                _doorsList[index].BackgroundColor = "#FFFFFF";
            }
        }


        #endregion
        #region Commands

        public ICommand EditDoorProx => new Command<string>(async (doorId) =>
        {
            var doorToEdit = Doors.FirstOrDefault(n => n.DoorId == doorId);
            if (doorToEdit != null)
            {
                var controlViewModel = new doorPopupViewModel(Navigation, doorToEdit, this);
                await PopupNavigation.Instance.PushAsync(new doorPopup(this) {BindingContext =  controlViewModel});
            }
        }); 

        public ICommand ButtonCmd => new Command<DoorsModel>((p) => updateState(p));
        #endregion
    }
}
