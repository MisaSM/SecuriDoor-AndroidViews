using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class DashboardViewModel : BaseViewModel {
        string title;

        public string Title {
            get { return title; }
            set { title = value; }
        }

        public DashboardViewModel() {
            Title = "Dashboard";

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }
        public ICommand OpenWebCommand { get; }
    }
}
