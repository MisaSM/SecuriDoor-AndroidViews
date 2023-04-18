using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Data;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.Views;
using Xamarin.Forms;
using static VistasSecuriDoor.Models.DoorsModel;

namespace VistasSecuriDoor.ViewModels
{
    public class controlPanelViewModel : BaseViewModel
    {

        #region Variables
        string _title = "Control de puertas";
        bool _isLoading = false;
        bool _spinnerVisible = false;
        public ObservableCollection<PlaceModel> _placeList;
        public ObservableCollection<DoorsModel> _doorsList;

        public controlPanelViewModel _cpVM;
        #endregion
        #region Contructor
        public controlPanelViewModel(INavigation navigation)
        {
            ShowDoors();
            Navigation = navigation;
            //ShowGroups();
        }
        #endregion
        #region Objetos
        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }



        public ObservableCollection<PlaceModel> Places
        {
            get { return _placeList; }
            set { SetProperty(ref _placeList, value); }
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
        public async Task ShowDoors()
        {
            IsLoading = true;
            SpinnerVisible = true;
            await Task.Delay(2000);
            Places = await DoorsData.ShowDoors();
            IsLoading = false;
            SpinnerVisible = false;
        }


        #endregion
        #region Commands

        #endregion
    }
}
