using BeanTea.Infrastructer;
using BeanTea.Models;
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

        public WatchService(ApiClient apiClient) 
        {
            _apClient = apiClient;
        }   

        public async Task<bool> AddWatch(BeanTeaWatchDto watch)
        {
            try
            {
                var url = "https://beanteaapi20231125145500.azurewebsites.net/api/watching?code=hHQCD9HODN2GZN8Pd3nmyBFyP5InQQWDey_mQG0dEeQnAzFuPizEDg==";

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
