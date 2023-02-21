using System;
using System.Collections.Generic;
using VistasSecuriDoor.ViewModels;
using VistasSecuriDoor.Views;
using Xamarin.Forms;

namespace VistasSecuriDoor
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
