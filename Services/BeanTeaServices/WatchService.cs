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

        public async Task<List<WatchFoundViewModel>> GetWatches(string email)
        {
            try
            {
                var url = $"{beanTeaBaseUrl}/api/getwatches?code={beanTeaApiKey}";
                var body = @"{""email"":"""+email+@"""}";

                var response = await _apClient.SendRequest(HttpMethod.Get, url, body);
                var res = await response.Content.ReadAsStringAsync();

                var watches = JsonConvert.DeserializeObject<List<WatchFoundViewModel>>(res);

                return watches;
            }
            catch (Exception ex)
            {
                return null;
            }
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

        internal async Task DeleteUserFoundWatch(string email, string url)
        {
            try
            {
                var requestUrl = $"{beanTeaBaseUrl}/api/deletewatch?code={beanTeaApiKey}";

                var DeleteUserFoundRequest = new
                {
                    Email = email,
                    Url = url
                };

                string json = JsonConvert.SerializeObject(DeleteUserFoundRequest);

                var response = await _apClient.SendRequest(HttpMethod.Delete, requestUrl, json);
               
            }
            catch (Exception ex)
            {
                var test = ex.Message.ToString();
            }
        }
    }
}
