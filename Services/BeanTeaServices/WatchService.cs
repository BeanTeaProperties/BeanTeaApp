using BeanTea.Infrastructer;
using BeanTea.Models;
using BeanTea.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeanTea.Services.BeanTeaServices
{
    public class WatchService
    {
        ApiClient _apClient;
        IConfiguration _config;
        string beanTeaBaseUrl;
        string beanTeaApiKey;

        public WatchService(ApiClient apiClient, IConfiguration configuration) 
        {
            _apClient = apiClient;
            _config = configuration;
            beanTeaApiKey = _config.GetConnectionString("BeanTeaApiKey");
            beanTeaBaseUrl = _config.GetConnectionString("BeanTeaApiUrl");
        }   

        public async Task<bool> AddWatch(BeanTeaWatchDto watch)
        {
            try
            {
                var url = $"{beanTeaBaseUrl}/api/watching?code={beanTeaApiKey}";

                await _apClient.SendRequest(HttpMethod.Post, url, JsonConvert.SerializeObject(watch));
                
                return true;
            }
            catch (Exception ex)
            {
               return false;
            }
        }

        //public async Task<List<WatchFoundViewModel>> ReturnWatchForUser(string email)
        //{
        //    var url = $"{beanTeaUrl}/api/watch?code={beanTeaApiKey}";

        //    var body = new
        //    {
        //        email = email
        //    };

        //    var assembly = Assembly.GetExecutingAssembly();
        //    using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.fakeWatchData.json");
        //    var sr = new StreamReader(stream);
        //    var data = sr.ReadToEnd();
        //    var jsonData = JsonConvert.DeserializeObject<List<WatchFoundViewModel>>(data);

        //    return jsonData;

        //}

        
        public async Task<List<WatchFoundViewModel>> GetUserWatchs(string email)
        {
            try
            {
                /// var url = $"{beanTeaBaseUrl}/api/watchfound?code={beanTeaApiKey}";

                //string url = "https://beanteaapi20231125145500.azurewebsites.net/api/watchfound?code=hHQCD9HODN2GZN8Pd3nmyBFyP5InQQWDey_mQG0dEeQnAzFuPizEDg==";
                //string body = "{\"email\":\"" + email + "\"}";


                //var json = new
                //{
                //    email = $"{email}"
                //};

                // var test = json.ToString();

                //    string jsonSent = JsonConvert.SerializeObject(json);

                var response = await _apClient.DeleteWatch();
                //var response = await _apClient.SendRequest(HttpMethod.Get, url, body);
                var responseString = await response.Content.ReadAsStringAsync();
                var watches = JsonConvert.DeserializeObject<List<WatchFoundViewModel>>(responseString);

                return watches;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task DeleteWatch(BeanTeaWatchDto deleteWatch)
        {
            try
            {
                var url = $"{beanTeaBaseUrl}/api/watchfound?code={beanTeaApiKey}";

                await _apClient.SendRequest(HttpMethod.Delete, url, JsonConvert.SerializeObject(deleteWatch));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
