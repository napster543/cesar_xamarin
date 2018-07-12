
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
        private string filter;
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
        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
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
        public ICommand SearchCommand
        {
            get
            { 
                return new RelayCommand(Search);
            }
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<Land>(
                    this.landList);
            }
            else
            {
                //https://www.youtube.com/watch?v=Zo4N-i2CsfA&list=PLuEZQoW9bRnSVLpBHr6fzrPnzaunFKwfe&index=14
                this.Lands = new ObservableCollection<Land>(
                    this.landList.Where(
                        l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Capital.ToLower().Contains(this.Filter.ToLower())
                    )
                );
            }
        }
    
        #endregion

    }
}
