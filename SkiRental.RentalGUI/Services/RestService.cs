using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SkiRental.RentalGUI.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.RentalGUI.Services
{
    public class RestService : IRestService
    {
        private string baseUrl;
        private HttpClient client;

        public RestService(string baseUrl)
        {
            this.baseUrl = baseUrl;

            var formatters = new MediaTypeFormatterCollection();
            formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new HttpStatusException(response.StatusCode, "Failed to request resource \"GET " + url + "\"");
            }
        }

        public async Task<T> PostAsync<T>(string url, T entity)
        {
            var response = await client.PostAsJsonAsync(url, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new HttpStatusException(response.StatusCode, "Failed to create resource \"POST " + url + "\"");
            }
        }

        public async Task DeleteAsync(string url)
        {
            var response = await client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpStatusException(response.StatusCode, "Failed to delete resource \"DELETE " + url + "\"");
            }
        }
    }
}
