﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Cesar_xamarin.ViewModels
{
    using Models;
    public class MainViewModel 
    {
        #region Propertys
        public List<Land> LandsList
        {
            get;
            set;
        }
        #endregion
        public LoginVIewModel Login
        {
            get;
            set;
        }
        public LandsViewModel Lands
        {

            get;
            set;

        }
        public LandViewModel Land
        {

            get;
            set;

        }
        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginVIewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
