using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Apu.Services
{
    public class DataService
    {
        public async static Task<dynamic> GetDataFromServiceAsync(string queryString)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(queryString);

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(json);
                return data;
            }
            return null;
        }

        public async static Task<T> GetDataFromServiceGenericAsync<T>(string queryString)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(queryString);

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
            return default(T);
        }
    }
}