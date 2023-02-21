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
            ProjDescription = "SecuriDoor es una aplicación y cerradura electrónica que ha sido diseñada para proporcionar seguridad en espacios interiores. Nuestra aplicación ha sido creada con el propósito de proteger tus bienes y tu privacidad, mediante el uso de tecnología avanzada y fácil de usar. Con SecuriDoor podrás controlar y monitorear el acceso a tus espacios de forma remota, lo cual te brinda tranquilidad y seguridad en todo momento. ¡Protege lo que más te importa con SecuriDoor!";

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}