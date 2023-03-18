using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistasSecuriDoor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VistasSecuriDoor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editGuestPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public editGuestPopup()
        {
            InitializeComponent();
        }
    }
}