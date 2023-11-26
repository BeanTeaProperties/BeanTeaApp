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
                       
            await _apiClient.SendRequest(HttpMethod.Post, "http://localhost:7071/api/user", JsonSerializer.Serialize(json));
        }
    }
}
