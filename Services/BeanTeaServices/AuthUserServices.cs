using BeanTea.Infrastructer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        public async Task<string> DecodeJwtToJSON(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            // Serialize the payload to JSON
            var payloadJson = JsonConvert.SerializeObject(jsonToken?.Payload, Formatting.Indented);

            return payloadJson;
        }
    }
}
