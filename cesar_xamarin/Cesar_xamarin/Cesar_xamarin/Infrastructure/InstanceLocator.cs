﻿ namespace Cesar_xamarin.Infrastructure
{
    using Xamarin.Forms;
    using ViewModels;
    public class InstanceLocator 
    {        
            #region Property
            public MainViewModel Main
            {
                get;
            // Modificado en DMS
                set;
            }
            #endregion

            #region constructor
            public InstanceLocator()
            {
                this.Main = new MainViewModel();
            }
            #endregion
        }
    

}
