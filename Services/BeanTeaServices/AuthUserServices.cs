using BeanTea.Infrastructer;
using Microsoft.Extensions.Configuration;
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
        IConfiguration _config;

        public AuthUserServices(ApiClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _config = configuration;
        }

        public async Task CreateUser(string email)
        {
            var apiKey = _config.GetConnectionString("BeanTeaApiKey");
            var url = _config.GetConnectionString("BeanTeaApiUrl");

            var json = new
            {
                email = email
            };
                       
            await _apiClient.SendRequest(HttpMethod.Post, $"{url}/api/user?code={apiKey}", JsonSerializer.Serialize(json));
        }
    }
}
