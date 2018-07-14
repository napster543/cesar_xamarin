
namespace Cesar_xamarin.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class LandItemViewModel : Land    
    {
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            } 
            
        }
        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }
    }
}
