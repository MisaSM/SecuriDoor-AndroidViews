using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VistasSecuriDoor.Models;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class editViewModel : BaseViewModel
    {
        public string guest_name;
        public string guest_lastname;
        public string guest_user;
        public string guest_pwd;


        public string GuestName
        {
            get { return guest_name; }
            set { SetProperty(ref guest_name, value); }
        }

        public string GuestLName
        {
            get { return guest_lastname; }
            set { SetProperty(ref guest_lastname, value); }
        }

        public string GuestUser
        {
            get { return guest_user; }
            set { SetProperty(ref guest_user, value); }
        }

        public string GuestPwd
        {
            get { return guest_pwd; }
            set { SetProperty(ref guest_pwd, value); }
        }

        public editViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public ICommand EditUserCommand => new Command(async () => 
        {
            await Application.Current.MainPage.DisplayAlert("Hola", "Probando", "Funcion!");
        });
    }
}
