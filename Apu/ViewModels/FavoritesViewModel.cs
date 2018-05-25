using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Apu.Models;

namespace Apu.ViewModels
{
    public class FavoritesViewModel
    {
        public ObservableCollection<City> Cities { get; set; }

        public FavoritesViewModel()
        {
           // Cities = new ObservableCollection<City>(App.DB.GetAllAsync()as IEnumerable<City>);
        }
       
    }
}
