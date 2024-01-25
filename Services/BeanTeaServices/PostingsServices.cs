using BeanTea.Infrastructer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeanTea.Models;
using Newtonsoft.Json;
using BeanTea.ViewModels;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;
using System.Reflection;
//using UIKit;

namespace BeanTea.Services.BeanTeaServices
{
    public class PostingsServices
    {
        ApiClient apiClient;
        IConfiguration _config;
        string beanTeaUrl;
        string beanTeaApiKey;

        public PostingsServices(IConfiguration configuration)
        {
            apiClient = new ApiClient();
            _config = configuration;
            beanTeaApiKey = _config.GetConnectionString("BeanTeaApiKey");
            beanTeaUrl = _config.GetConnectionString("BeanTeaApiUrl");
        }

        public async Task<bool> IsItADeadLink(string url)
        {
            try
            {
                var response = await apiClient.SendRequest(HttpMethod.Get, url);
                return !response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                return ex.StatusCode == System.Net.HttpStatusCode.Gone;
            }
            catch
            {
                return true;
            }
        }

        public async Task RemovePosting(string posting)
        {
            var url = $"{beanTeaUrl}/api/renting?code={beanTeaApiKey}";

            await apiClient.SendRequest(HttpMethod.Delete, url, posting);
        }

        public async Task<List<WatchFoundViewModel>> ReturnWatchForUser(string email)
        {
            var url = $"{beanTeaUrl}/api/watch?code={beanTeaApiKey}";

            var body = new
            {
                email = email
            };

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.fakeWatchData.json");
            var sr = new StreamReader(stream);  
            var data = sr.ReadToEnd();
            var jsonData = JsonConvert.DeserializeObject<List<WatchFoundViewModel>>(data);

            return jsonData;

        }

        public async Task DeleteWatchFound(WatchFoundViewModel watch)
        {
            var url = $"{beanTeaUrl}/api/watch?code={beanTeaApiKey}";

            await apiClient.SendRequest(HttpMethod.Delete, url, JsonConvert.SerializeObject(watch));
        }

        public async Task<List<LocationDataDto>> ReturnPostings(int min, int max)
        {
            var request = new
            {
                Min = min,
                Max = max
            };

            var url = $"{beanTeaUrl}/api/renting?code={beanTeaApiKey}";

            var response = await apiClient.SendRequest(HttpMethod.Post, url, JsonConvert.SerializeObject(request));
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<LocationDataDto>>(responseString);

            return result;

        }

        public async Task<List<SearchResultViewModel>> FilterSearchResult(List<LocationDataDto> searchResults, Location searchLocation, int distance)
        {
            var locations = new List<SearchResultViewModel>();

            foreach (var searchResult in searchResults)
            {
                double searchResultLat = double.Parse(searchResult.Latitude);
                double searchResultLon = double.Parse(searchResult.Longitude);

                double distanceToSearchLocation = CalculateDistance(
                    searchLocation.Latitude,
                    searchLocation.Longitude,
                    searchResultLat,
                    searchResultLon);

                // Convert distance to kilometers if needed (depends on how 'distance' is defined)
                if (distanceToSearchLocation <= distance)
                {
                    locations.Add(new SearchResultViewModel() { longitude = searchResult.Longitude, latitude = searchResult.Latitude, area = searchResult.Location, title = searchResult.Title,  price = searchResult.Price, url = searchResult.Url});
                }
            }

            return locations;
        }

        private double ToRadians(double angleInDegrees)
        {
            return angleInDegrees * (Math.PI / 180);
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadius = 6371; // Radius of the Earth in kilometers
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadius * c;
        }


    }
}
