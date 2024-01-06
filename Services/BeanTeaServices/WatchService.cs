using BeanTea.Infrastructer;
using BeanTea.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                // ConfigApp code
                var url = $"{beanTeaBaseUrl}/api/watching?code={beanTeaApiKey}";

                await _apClient.SendRequest(HttpMethod.Post, url, JsonConvert.SerializeObject(watch));
                
                return true;
            }
            catch (Exception ex)
            {
               return false;
            }
        }
    }
}
