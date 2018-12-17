using System.Collections.Generic;
using Newtonsoft.Json;

namespace Services.Responses
{
    public class ResponseBase
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "terms")]
        public string Terms { get; set; }

        [JsonProperty(PropertyName = "privacy")]
        public string Privacy { get; set; }

        [JsonProperty(PropertyName = "error")]
        public ResponseError Error { get; set; }
    }
}