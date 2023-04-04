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

        public string _msg;
        public bool UserAuth
        {
            get { return _userAuth; }
            set { SetProperty(ref _userAuth, value); }
        }

        public string Message 
        {
            get { return _msg; }
            set { SetProperty(ref _msg, value);}
        }

        public AppShellVM()
        {
            MessagingCenter.Subscribe<LoginViewModel, bool>(this, "IsOwner?", (sender, isOwner) =>
            {
                UserAuth = isOwner;
                Debug.WriteLine($"IsOwner? {UserAuth}");
            });
            MessagingCenter.Subscribe<LoginViewModel, string>(this, "messageStatus", (sender, messageStatus) => 
            {
                Message = messageStatus;
                Debug.WriteLine(Message);
            });
        }

    }
}
