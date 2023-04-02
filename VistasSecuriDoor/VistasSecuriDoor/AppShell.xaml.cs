using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using VistasSecuriDoor.Data;
using VistasSecuriDoor.ViewModels;
using VistasSecuriDoor.Views;
using Xamarin.Forms;
using System.Windows.Input;

namespace VistasSecuriDoor
{
    public partial class AppShell : Xamarin.Forms.Shell
    { 
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(registerOwner), typeof(registerOwner));
            this.BindingContext = new AppShellVM();
        }

        public async void LogoutItem_Clicked(object sender, EventArgs e)
        {
            //Despeja los datos almacenados en cache
            Application.Current.Properties["token"] = null;
            Application.Current.Properties["isOwner"] = null;
            await Application.Current.SavePropertiesAsync();
            await Current.GoToAsync("//LoginPage");

            Debug.WriteLine(Application.Current.Properties["token"]);
            Debug.WriteLine(Application.Current.Properties["isOwner"]);
        }
    }
}
