using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using App2.Models;
using App2.Views;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace App2.Services
{
    class RestApi
    {

        HttpClient _client = new HttpClient();
        public async Task<T> Get<T>(string url, string tok)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tok);
            var response = await _client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var accounts = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                return accounts;
            }

            return default(T);
        }
        public async Task<Object> Post(object User, string url)
        {
            var json = JsonConvert.SerializeObject(User);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(url, content);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultJson = result.Content.ReadAsStringAsync().Result;
                var tk = JsonConvert.DeserializeObject<Token>(resultJson);
                return tk;
            }
            else
            {
                return result.RequestMessage;
            }
        }

    }
}
