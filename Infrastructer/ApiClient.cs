
namespace BeanTea.Infrastructer
{
    public class ApiClient
    {
        public async Task<HttpResponseMessage> SendReuest(HttpMethod method, string url, string body = "")
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = new Uri(url);
            request.Content = new StringContent(body);

            request.Headers.Add("Authorization", await SecureStorage.GetAsync("auth-token"));
          
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            
            return response;
        }
    }
}
