

namespace Cesar_xamarin.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Text;
    using System.Windows.Input;

    using Views;
    using Xamarin.Forms;
    public class LoginVIewModel : BaseViewModel
    {
        #region Events
       // public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Attribes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
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
            this.IsRunning = true;
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
            
            this.IsEnabled = false;

            //https://www.youtube.com/watch?v=JIFT4GY1qFg
            //part 9 tiempo: 0:0 inicia desde cero 

            if (this.Email != "cessar_4@hotmail.com" || this.Password != "102")
            {
                this.IsRunning = false;
                this.IsEnabled= true;
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Email o password incorrect.",
                "Accept");
                this.Password = string.Empty;
                return;
            }
            

                this.IsRunning = false;
                this.IsEnabled = true;
            

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            this.Email = string.Empty;
            this.Password = string.Empty;
        }

        
        public LoginVIewModel()
        {
            this.IsRemembered = true;
            this.IsRunning = false;
            this.IsEnabled = true;
            this.Email = "cessar_4@hotmail.com";
            this.Password = "102";
            // te muestra todos los paises
            //https://restcountries.eu/rest/v2/all

        }
    }
}
