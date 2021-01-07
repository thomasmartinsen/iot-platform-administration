using Newtonsoft.Json;

namespace iot_platform_administration.Data.Models.Api
{
    public class CustomerClientKey
    {
        [JsonProperty(PropertyName = "clientKey")]
        public string ClientKey { get; set; }

        [JsonProperty(PropertyName = "verticalId")]
        public string VerticalId { get; set; }

        [JsonProperty(PropertyName = "roleType")]
        public int RoleType { get; set; }
    }
}
