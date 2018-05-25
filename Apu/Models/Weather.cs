using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apu.Models
{
    public class Weather
    {
        [JsonProperty(PropertyName = "name")]
        public string City { get; set; } = "";

        [JsonProperty(PropertyName = "main.temp")]
        public string Temperature { get; set; } = "";

        [JsonProperty(PropertyName = "speed")]
        public string Wind { get; set; } = "";

        [JsonProperty(PropertyName = "humidity")]
        public string Humidity { get; set; } = "";

        [JsonProperty(PropertyName = "visibility")]
        public string Visibility { get; set; } = "";

        public Sun Sun { get; set; } = new Sun();

        public string Icon { get; set; } = "";



    }

    public class Sun
    {
        [JsonProperty(PropertyName = "sunrise")]
        public DateTime Sunrise { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "sunset")]
        public DateTime Sunset { get; set; } = DateTime.Now;
    }

}