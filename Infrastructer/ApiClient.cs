﻿
namespace BeanTea.Infrastructer
{
    public class ApiClient
    {
        public async Task<HttpResponseMessage> SendRequest(HttpMethod method, string url, string body = null)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = new Uri(url);

            if (body != null)
            {
                request.Content = new StringContent(body);
            }

            var token = await SecureStorage.GetAsync("access-token");
            if (token != null) {
                request.Headers.Add("Authorization", token);
            }
          
          
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            
            return response;
        }
    }
}
