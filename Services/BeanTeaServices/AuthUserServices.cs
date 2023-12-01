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
                       
            await _apiClient.SendRequest(HttpMethod.Post, "https://beanteaapi20231125145500.azurewebsites.net/api/user?code=hHQCD9HODN2GZN8Pd3nmyBFyP5InQQWDey_mQG0dEeQnAzFuPizEDg==", JsonSerializer.Serialize(json));
        }
    }
}
