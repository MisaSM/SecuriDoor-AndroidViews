using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        string projDescription;
        string title;


        public string Title 
        {
            get 
            {
                return title;
            }
            set 
            {
                title = value;
            }
        }

        public string ProjDescription 
        { 
            get 
            {
                return projDescription;
            }
            set 
            {
                projDescription = value;
            }
        }

        public AboutViewModel()
        {
            Title = "Acerca de nosotros";
            ProjDescription = "SecuriDoor es un sistema de gestión para una cerradura electrónica del mismo nombre, su propósito es resguardar la integridad y seguridad de los espacios en la que se utilice la cerradura.";

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}