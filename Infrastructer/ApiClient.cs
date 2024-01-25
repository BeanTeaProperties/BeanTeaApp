
using RestSharp;

namespace BeanTea.Infrastructer
{
    public class ApiClient
    {

        public async Task<dynamic> DeleteWatch()
        {
            var options = new RestClientOptions("https://beanteaapi20231125145500.azurewebsites.net")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/getwatches?code=hHQCD9HODN2GZN8Pd3nmyBFyP5InQQWDey_mQG0dEeQnAzFuPizEDg==", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{""email"":""con.mcg1988@gmail.com""}
" + "\n" +
            @"";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        //public async Task<dynamic> DeleteWatch()
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage(HttpMethod.Get, "https://beanteaapi20231125145500.azurewebsites.net/api/watchfound");
        // //   request.Headers.Add("Authorization", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik1FTXlORE0wUWtRMVJURkRPRUZGUWpRNE1rSXdNekV6TjBGRE5UZENRek0zUlVJelEwUkVSQSJ9.eyJnaXZlbl9uYW1lIjoiQ29uIiwiZmFtaWx5X25hbWUiOiJXb29kcyIsIm5pY2tuYW1lIjoiY29uLm1jZzE5ODgiLCJuYW1lIjoiQ29uIFdvb2RzIiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS9hL0FDZzhvY0tKN1FmYy0zUXV1a1d4cnVIdlUySjJpbFRCNjA1SERuNXNRR2x4LTZESz1zOTYtYyIsImxvY2FsZSI6ImVuIiwidXBkYXRlZF9hdCI6IjIwMjQtMDEtMTBUMDY6NTM6NDEuNjQzWiIsImVtYWlsIjoiY29uLm1jZzE5ODhAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsImlzcyI6Imh0dHBzOi8vbGVuZGVycy5hdXRoMC5jb20vIiwiYXVkIjoidzFMTzA3UDFPc1ZxdlJMR3dHR2E1WDkwVEc0bFRZOGwiLCJpYXQiOjE3MDQ5NDkxNDgsImV4cCI6MTcwNDk4NTE0OCwic3ViIjoiZ29vZ2xlLW9hdXRoMnwxMDMwNzQwNjcwNzUyMDg5NzU2NDQiLCJzaWQiOiJ4ekVVcEdMeE5uT05NTTE0cm51dXdjYlVQR2xsZVVVbyJ9.dyH_8nl81-dDTH51LUefqGULj4d7RQmGHsRKt71ZsRyt1u60OvpdETuP9teSSt4UffcXxuUfOe9c6S4G2MAuJsiFqus9C0WpWZyQ_Ucg-Zyc0z81ZpTWY-wwUsanjDjZ4tPZ1WMAseUsip0FeDf_GCgvRcZAyFEEwYECAr7M9yw7wGIpcj2iSnR_esoH0yQ1zqY-X6FC9yGqaeomuEalqi1sRlOqIen4B-qoDfYSNohtdxf3VKMhGW7QGjAF2TXTf68lq3XZz69PntcQRM5OhImlB5R5sISSsi8LtNpI_5erIDA-IQ5-eoTBHaPUYiFEhyBqpRm22q1eRs8j8qMqVA");
        //    var content = new StringContent("  {\r\n        \"email\": \"con.mcg1988@gmail.com\",\r\n        \"url\": \"https://vancouver.craigslist.org/bnc/apa/d/coquitlam-north-bed-bath-furnished/7705543402.html\",\r\n        \"area\": \" burnaby/newwest \",\r\n        \"title\": \"2 Bed 2 Bath Furnished Penthouse at Timberlea Tower A in Burnaby\",\r\n        \"price\": \"$2,950\",\r\n        \"partitionKey\": \"con.mcg1988@gmail.com\",\r\n        \"rowKey\": \"00718b03197f090853de1da0b47f8441\",\r\n        \"timestamp\": \"2024-01-08T22:09:58.6371221+00:00\",\r\n        \"eTag\": {}\r\n    }", null, "application/json");
        //    request.Content = content;
        //    var response = await client.SendAsync(request);
        //    response.EnsureSuccessStatusCode();

        //    return response;
        //    //Console.WriteLine(await response.Content.ReadAsStringAsync());

        //}

        public async Task<dynamic> GetWatches()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://beanteaapi20231125145500.azurewebsites.net/api/watchfound");
            var content = new StringContent("{\"email\":\"con.mcg1988@gmail.com\"}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
          //  response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());



            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, "https://beanteaapi20231125145500.azurewebsites.net/api/watchfound?code=hHQCD9HODN2GZN8Pd3nmyBFyP5InQQWDey_mQG0dEeQnAzFuPizEDg==");
            //var content = new StringContent("{\"email\":\"con.mcg1988@gmail.com\"}", null, "application/json");
            //request.Content = content;
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());

            return response;

        }

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
