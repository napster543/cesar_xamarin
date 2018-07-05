using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Cesar_xamarin.ViewModels
{
    public class MainViewModel 
    {
        public LoginVIewModel Login
        {
            get;
            set;
        }
        public MainViewModel()
        {
            this.Login = new LoginVIewModel();
        }
    }
}
