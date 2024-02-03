using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanTea.Models
{
    
    public class BeanTeaWatchDto
    {
        public BeanTeaWatchDto(int propertyTypeEnum, int max, int distance, string lat, string lon, string email)
        {
            PropertyTypeEnum = propertyTypeEnum;
            Max = max;
            Distance = distance;
            Lat = lat;
            Lon = lon;
            Email = email;
        }

        public int PropertyTypeEnum { get; set; }
        public int Max { get; set; }
        public int Distance { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Email { get; set; }
    }

}
