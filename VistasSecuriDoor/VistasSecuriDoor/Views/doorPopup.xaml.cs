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
    public partial class doorPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public doorPopup(controlPanelViewModel cpVM)
        {
            InitializeComponent();
        }

        public class AnimatePopupAction : TriggerAction<Grid>
        {
            protected override async void Invoke(Grid sender)
            {
                await sender.ScaleTo(1.2, 100);
                await sender.ScaleTo(1, 100);
            }
        }

    }
}