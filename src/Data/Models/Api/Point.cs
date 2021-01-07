using System.Collections.Generic;
using Newtonsoft.Json;

namespace iot_platform_administration.Data.Models.Api
{
    public class Point
    {
        public Point()
        {
            CustomerId = string.Empty;
            VerticalId = string.Empty;
            Name = string.Empty;
            Devices = new List<Device>();
            Tags = new List<string>();
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "verticalId")]
        public string VerticalId { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public dynamic? Attributes { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "devices")]
        public List<Device> Devices { get; set; }
    }
}
