using BeanTea.Infrastructer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeanTea.Services.BeanTeaServices
{
    public class AuthUserServices
    {
        ApiClient _apiClient; 
        
        public AuthUserServices(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task CreateUser(string email)
        {
            var json = new
            {
                email = email
            };
                       
            await _apiClient.SendReuest(HttpMethod.Post, "https://webhook.site/888b59c7-8db0-4795-833c-26afe22e65bc", JsonSerializer.Serialize(json));
        }
    }
}
