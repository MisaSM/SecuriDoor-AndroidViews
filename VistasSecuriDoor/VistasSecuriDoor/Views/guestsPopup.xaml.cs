using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VistasSecuriDoor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class guestsPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public guestsPopup(usersManagementViewModel uservm)
        {
            InitializeComponent();
            this.BindingContext = new PopupViewModel(Navigation, uservm);
        }
    }
}