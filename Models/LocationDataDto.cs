using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanTea.Models
{
    public class LocationDataDto
    {
        public string Location { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTime Timestamp { get; set; }
        public object ETag { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public int NumberOfBedrooms { get; set; }
        public PropertyType PropertyType { get; set; }
        public string Url { get; set; }
    }

}
