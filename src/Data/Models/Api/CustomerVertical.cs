using Newtonsoft.Json;

namespace iot_platform_administration.Data.Models.Api
{
    public class CustomerVertical
    {
        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "verticalId")]
        public string VerticalId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public dynamic Attributes { get; set; }
    }
}
