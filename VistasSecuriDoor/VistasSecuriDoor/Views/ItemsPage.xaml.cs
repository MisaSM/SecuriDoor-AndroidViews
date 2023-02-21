using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.ViewModels;
using VistasSecuriDoor.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VistasSecuriDoor.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}