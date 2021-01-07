using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iot_platform_administration.Data.Models.Api
{
    public class Measurement
    {
        public Measurement()
        {
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }

        [JsonProperty(PropertyName = "device")]
        public string DeviceId { get; set; }

        [JsonProperty(PropertyName = "measurementType")]
        public string MeasurementType { get; set; }
    }
}
