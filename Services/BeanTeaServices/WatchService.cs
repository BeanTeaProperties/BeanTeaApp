using BeanTea.Infrastructer;
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

        public async Task<bool> AddWatch(string jsonLocation)
        {
            try
            {
                await _apClient.SendRequest(HttpMethod.Post, "https://webhook.site/888b59c7-8db0-4795-833c-26afe22e65bc", JsonConvert.SerializeObject(jsonLocation));
                return true;
            }
            catch (Exception ex)
            {
               return false;
            }
        }
    }
}
