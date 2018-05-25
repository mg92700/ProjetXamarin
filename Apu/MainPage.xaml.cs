using Apu.Models;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Apu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void BtnSearchClicked(object sender, EventArgs e)
        {
            string villeName = EntryCity.Text;
            if (!string.IsNullOrEmpty(villeName))
            {
                Weather weather = await Services.WeatherService.GetWeatherByCity(villeName);
                if (weather != null)
                {
                    BindingContext = weather;
                }
                else
                {
                    await DisplayAlert("Erreur", "Ville inconue", "OK");

                }
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez renseigner le nom d'une ville", "OK");
            }
        }

        public async void BtnGeoClicked(object sender, EventArgs e)
        {
            if (CrossGeolocator.IsSupported)
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 200;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                var logitude = position.Longitude;
                var latitude = position.Latitude;

                Weather weather = await Services.WeatherService.GetWeatherByGeoLoc(latitude, logitude);
                BindingContext = weather;
            }
            else
            {
                await DisplayAlert("Erreur", "Activer la géolocalisation", "OK");
            }
        }


        public async void AddFavoriteClicked(object sender, EventArgs e)
        {

        }
    }
}