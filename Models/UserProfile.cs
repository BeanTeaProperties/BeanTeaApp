using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanTea.Models
{
    public class UserProfile
    {
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Locale { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
        public int Iat { get; set; }
        public int Exp { get; set; }
        public string Sub { get; set; }
        public string Sid { get; set; }
    }

}
