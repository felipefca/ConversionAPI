using Newtonsoft.Json;

namespace Services.Responses
{
    public class ResponseError
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }
    }
}