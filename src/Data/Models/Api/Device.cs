using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace iot_platform_administration.Data.Models.Api
{
    public class Device
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty(PropertyName = "deviceType")]
        public string DeviceType { get; set; }

        [JsonProperty(PropertyName = "forecastTypes")]
        public IEnumerable<int> ForecastTypes { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty(PropertyName = "lastSeen")]
        public DateTime? LastSeen { get; set; }

        [JsonProperty(PropertyName = "verticalId")]
        public string VerticalId { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public dynamic Attributes { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "measurements")]
        public List<Measurement> Measurements { get; set; }
    }
}
