using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using VistasSecuriDoor.Data;
using VistasSecuriDoor.Services;
using VistasSecuriDoor.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            //Debug.WriteLine(Application.Current.Properties["token"]);
            //clearCache();
        }

        protected override void OnSleep()
        {
            clearCache();
        }

        public void clearCache() 
        {
            Application.Current.Properties["token"] = "";
            Application.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
        }
    }
}
