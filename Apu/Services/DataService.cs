using Apu.Models;
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


        public class Post         {              public int Id { get; set; }             public string Title { get; set; }             public string Body { get; set; }         }         public async static Task<dynamic> PostValueAsync()         {                              var client = new HttpClient();             var novoPost = new Post                       {                           Id = 12,                           Title = "My First Post",                                Body = "Macoratti .net - Quase tudo para .NET!"                       } ;                          // create the request content and define Json                       var json = JsonConvert.SerializeObject(novoPost);                       var content = new StringContent(json, Encoding.UTF8, "application/json");                          //  send a POST request                       var uri = "http://jsonplaceholder.typicode.com/posts";                       var result = await client.PostAsync(uri, content);                          // on error throw a exception                       result.EnsureSuccessStatusCode();                          // handling the answer                       var resultString = await result.Content.ReadAsStringAsync();                       var post = JsonConvert.DeserializeObject<Post>(resultString);               return post;         } 

    }
}