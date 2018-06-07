using Apu.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Apu.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<City> Cities { get; set; }

        public Command LoadCitiesCommand { get; set; }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); /*isBusy = value;*/ }
        }

        public FavoritesViewModel()
        {
            Cities = new ObservableCollection<City>();
            LoadCitiesCommand = new Command(async () => await ExecuteLoadCitiesCommand());
            //var c = new City {Name = "Marseille", Order = 1 };

            //App.DB.SaveAsync(c);
            //var test = App.DB.GetAllAsync() as IEnumerable<City>;
            /*Cities = new ObservableCollection<City>(
                 App.DB.GetAllAsync() as IEnumerable<City>);*/
        }

        protected async Task ExecuteLoadCitiesCommand()
        {
            IsBusy = true;
            try
            {
                Cities.Clear();
                var cities = await App.DB.GetAllAsync();
                foreach (var item in cities)
                {
                    Cities.Add(item);
                }
            }
            catch (Exception) { }
            IsBusy = false;
        }
    }
}
