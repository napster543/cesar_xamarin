﻿
namespace Cesar_xamarin.ViewModels
{
    using Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Services;
    using Xamarin.Forms;
    using System.Windows.Input;    
    using GalaSoft.MvvmLight.Command;

    
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LandsViewModel : BaseViewModel
    {
        #region services
        private ApiService apiService;
        #endregion
        #region Attributes
        private ObservableCollection<Land> lands;
        private bool isRefreshing;
        private List<Land> landList;
        #endregion  
        #region Property
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion
            #region constructor
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Method
        private async void  LoadLands()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await this.apiService.GetList<Land>(
                 "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                 await Application.Current.MainPage.Navigation.PopAsync();
                
                return;
            } 
                this.landList = (List<Land>)response.Result;
                this.Lands = new  ObservableCollection<Land>(this.landList);
           
            this.IsRefreshing = false;
            
        }
        #endregion

        #region Commands
        public ICommand RefreshListCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }
        #endregion

    }
}
