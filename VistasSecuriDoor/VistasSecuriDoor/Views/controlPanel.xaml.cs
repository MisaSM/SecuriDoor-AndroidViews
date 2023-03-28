using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class controlPanel : ContentPage
    {
        public controlPanel()
        {
            
            InitializeComponent();
            this.BindingContext = new controlPanelViewModel(Navigation);
        }
    }
}