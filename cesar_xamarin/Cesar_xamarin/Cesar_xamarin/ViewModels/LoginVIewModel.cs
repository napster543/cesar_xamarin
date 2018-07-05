using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cesar_xamarin.ViewModels
{
    public class LoginVIewModel : BaseViewModel
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Attribes
        
        private string password;
        private bool isRuning;
        private bool isEnabled;

        #endregion

        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRuning
        {
            get { return this.isRuning; }
            set { SetValue(ref this.isRuning, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
            
        }

        

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Tienes que ingresar un E-mail.", 
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Tienes que ingresar un Password.",
                    "Aceptar");
                return;
            }
            this.IsRuning = true;
            this.IsEnabled = false;

            //https://www.youtube.com/watch?v=JIFT4GY1qFg
            // part 9 tiempo: 0:0 inicia desde cero 

            if (this.Email != "cessar_4@hotmail.com" || this.Password != "102")
            {
                this.IsRuning = false;
                this.IsEnabled= true;
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Email o password incorrect.",
                "Accept");
                this.Password = string.Empty;
                return;
            }
            

                this.IsRuning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                "Ok",
                "Excelent Yeah!!!",
                "Aceptar");
                return;
            
        }

        
        public LoginVIewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
    }
}
