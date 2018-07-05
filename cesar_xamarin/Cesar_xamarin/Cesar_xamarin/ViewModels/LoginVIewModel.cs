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
    public class LoginVIewModel : INotifyPropertyChanged
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
            get
            {
                return password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(this.Password)));
                }
            }
        }
        public bool IsRuning
        {
            get
            {
                return this.isRuning;
            }
            set
            {
                if (this.isRuning != value)
                {
                    this.isRuning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(this.IsRuning)));
                }
            }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(this.IsEnabled)));
                }
            }
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

            if (this.Email != "cessar_4@hotmail.com" && this.Password != "102")
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
