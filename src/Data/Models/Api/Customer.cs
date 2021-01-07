using System.Collections.Generic;
using Newtonsoft.Json;

namespace iot_platform_administration.Data.Models.Api
{
    public class Customer
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "clientKeys")]
        public IEnumerable<CustomerClientKey> ClientKeys { get; set; }

        [JsonProperty(PropertyName = "vertical")]
        public CustomerVertical Vertical { get; set; }

        [JsonProperty(PropertyName = "isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty(PropertyName = "gateway")]
        public Gateway Gateway { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }
    }
}
