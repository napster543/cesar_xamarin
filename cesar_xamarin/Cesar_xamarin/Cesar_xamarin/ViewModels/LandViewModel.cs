

namespace Cesar_xamarin.ViewModels
{
    using Models;
    public class LandViewModel
    {
        #region Property
        public Land Land
        {
            get;
            set;
        }         
        #endregion

        #region Constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
        } 
        #endregion
    }
}