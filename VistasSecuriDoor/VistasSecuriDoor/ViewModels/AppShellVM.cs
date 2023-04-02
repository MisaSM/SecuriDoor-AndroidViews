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
        public bool _userAuth;
        
        public bool UserAuth
        {
            get { return _userAuth; }
            set { SetProperty(ref _userAuth, value); }
        }

        public AppShellVM()
        {
            MessagingCenter.Subscribe<LoginViewModel, bool>(this, "IsOwner?", (sender, isOwner) =>
            {
                UserAuth = isOwner;
                Debug.WriteLine($"IsOwner? {UserAuth}");
            });
        }

    }
}
