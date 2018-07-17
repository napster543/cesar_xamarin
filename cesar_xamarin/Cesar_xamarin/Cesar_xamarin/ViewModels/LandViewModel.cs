﻿

namespace Cesar_xamarin.ViewModels
{
    using Models;
    using System.Linq;
    using System;
    using System.Collections.ObjectModel;

    public class LandViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Border> borders;
        #endregion

        #region Property
        public Land Land
        {
            get;
            set;
        }
        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { SetValue(ref this.borders, value); }
        }
        #endregion

        #region Constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
        }


        #endregion
        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.
                    Where(l => l.Alpha3Code == border).
                    FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name
                    });
                }

            }
        } 
        #endregion
    }
}