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
    public partial class notifyPage : ContentPage
    {
        public notifyPage()
        {
            InitializeComponent();
            this.BindingContext = new NotificationsViewModel(Navigation);
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}