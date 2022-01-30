using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NP5lab
{
    public class Department
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("index")]
        public string Index { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonIgnore]
        public string Description => $"{City} : {Name}. {Address}";
        public string AddressList => $"{Address}";
        public string[] Info()
        {
            string[] list = new string[3];
            list[0] = $"{Index}: {Name}";
            list[1] = $"phone: {Phone}";
            list[2] = $"email: {Email}";
            return list;
        }

    }


}
