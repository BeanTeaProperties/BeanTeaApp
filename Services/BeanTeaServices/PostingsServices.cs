using BeanTea.Infrastructer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeanTea.Models;
using Newtonsoft.Json;

namespace BeanTea.Services.BeanTeaServices
{

    public class PostingsServices
    {
        ApiClient apiClient;

        public PostingsServices()
        {
            apiClient = new ApiClient();
        }

        public async Task<List<LocationDataDto>> ReturnPostings(int min, int max)
        {
            var request = new
            {
                Min = min,
                Max = max
            };

            var url = "https://beanteaapi20231125145500.azurewebsites.net/api/renting?code=hHQCD9HODN2GZN8Pd3nmyBFyP5InQQWDey_mQG0dEeQnAzFuPizEDg==";

            var response = await apiClient.SendRequest(HttpMethod.Post, url, JsonConvert.SerializeObject(request));
            var test = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<LocationDataDto>>(test);

            return result;

        }

        public async Task<List<Location>> FilterSearchResult(List<LocationDataDto> searchResults, Location searchLocation, int distance)
        {
            var locations = new List<Location>();

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
                    locations.Add(new Location { Latitude = searchResultLat, Longitude = searchResultLon });
                }
            }


            return locations;
        }

        public class LocationData
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public Location RandomizeLocation(Location originalLocation, double maxOffsetInMeters)
        {
            Random random = new Random();

            // Earth's radius in meters
            double earthRadius = 6_371_000;

            // Convert offset from meters to degrees
            double maxOffsetInDegrees = maxOffsetInMeters / earthRadius * (180 / Math.PI);

            // Generate a random offset, ensuring it's within the specified range
            double latitudeOffset = maxOffsetInDegrees * (random.NextDouble() - 0.5) * 2;
            double longitudeOffset = maxOffsetInDegrees * (random.NextDouble() - 0.5) * 2;

            return new Location
            {
                Latitude = originalLocation.Latitude + latitudeOffset,
                Longitude = originalLocation.Longitude + longitudeOffset
            };
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
