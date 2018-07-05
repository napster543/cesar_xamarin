using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cesar_xamarin.ViewModels
{
    public class LoginVIewModel 
    {
        public string Email {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool IsRuning
        {
            get;
            set;
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public ICommand LoginCommand
        {
            get;
            set;
        }
        public ICommand RegisterCommand
        {
            get;
            set;
        }
        public LoginVIewModel()
        {
            this.IsRemembered = true;
        }
    }
}
