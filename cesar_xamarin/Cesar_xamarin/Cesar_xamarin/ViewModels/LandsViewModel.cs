
namespace Cesar_xamarin.ViewModels
{
    using Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        private ApiService apiService;
        #region Attributes
        private ObservableCollection<Land> lands;
        #endregion  
        #region Property
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
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
        public async void  LoadLands()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
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

            if (response.IsSuccess) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            } 

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);

        }
        #endregion
    }
}
