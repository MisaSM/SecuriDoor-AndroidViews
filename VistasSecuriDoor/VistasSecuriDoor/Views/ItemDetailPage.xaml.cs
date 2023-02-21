using System.ComponentModel;
using VistasSecuriDoor.ViewModels;
using Xamarin.Forms;

namespace VistasSecuriDoor.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}