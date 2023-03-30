using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VistasSecuriDoor.ViewModels
{
    public class AppShellVM : BaseViewModel
    {

        //Lo que se planea lograr es acceder al dato generado por el isLoggedIn
        //algo que se me acaba de ocurrir es pasar la instancia del AppShellVM hacia el LoginViewModel y desde ahí
        //darle el valor a UserAuth, en caso de que no lo hagas tu lo intentaré yo más tarde :)
        public bool _userAuth;
        

        public bool UserAuth
        {
            get { return _userAuth; }
            set { SetProperty(ref _userAuth, value); }
        }

        public AppShellVM()
        {
            Debug.WriteLine(Application.Current.Properties["isOwner"]);
            
        }

        


    }
}
