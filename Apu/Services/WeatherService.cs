using Apu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apu.Services
{
    public class WeatherService
    {
        const string url = "http://api.openweathermap.org/data/2.5/weather?";
        const string key = "6771b98c28f9b75e2b459b5d13e82eae";

        public static async Task<Weather> GetWeatherByCity(string city)
        {
            string queryString = $"{url}q={city}&appid={key}&units=metric";
            return await GetDataAsync(queryString);
        }

        private async static Task<Weather> GetDataGenericAsync(string queryString)
        {
            return await DataService.GetDataFromServiceGenericAsync<Weather>(queryString).ConfigureAwait(false);
        }

        private async static Task<Weather> GetDataAsync(string queryString)
        {
            var result = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (result != null)
            {
                var weather = new Weather();
                weather.City = result["name"];
                weather.Temperature = result["main"]["temp"].ToString().Replace(",", ".")+"°C";
                weather.Humidity = result["main"]["humidity"].ToString().Replace(",", ".")+"%";
                weather.Wind = result["wind"]["speed"].ToString().Replace(",", ".")+"Km";
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0);
                weather.Sun.Sunrise = time.AddSeconds((double)result["sys"]["sunrise"] + 7200);
                weather.Sun.Sunset = time.AddSeconds((double)result["sys"]["sunset"] + 7200);
                weather.Icon = result["weather"][0]["icon"].ToString();
                return weather;
            }

            return null;
        }

        public async static Task<Weather> GetWeatherByGeoLoc(double latitude, double logitude)
        {
            string queryString = $"{url}lat={latitude}&lon={logitude}&appid={key}&units=metric";
            return await GetDataAsync(queryString);
        }
    }
}