using Newtonsoft.Json;

namespace iot_platform_administration.Data.Models.Api
{
    public class Gateway
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
    }
}
