using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class DashboardViewModel : BaseViewModel {
        string pageSource;

        public string PageSource 
        {
            get { return pageSource; }
            set { SetProperty(ref pageSource, value); }
        }


        public DashboardViewModel() {

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            PageSource = "https://www.youtube.com";
        }
        public ICommand OpenWebCommand { get; }
    }
}
