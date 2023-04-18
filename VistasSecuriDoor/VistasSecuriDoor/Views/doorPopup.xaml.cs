using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VistasSecuriDoor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class doorPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public doorPopup(DoorsModel door)
        {
            InitializeComponent();
            this.BindingContext = new doorPopupViewModel(Navigation, door);
        }


    }
}