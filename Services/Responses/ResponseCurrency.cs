using System.Collections.Generic;
using Newtonsoft.Json;

namespace Services.Responses
{
    public class ResponseCurrency : ResponseBase
    {
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "quotes")]
        public Dictionary<string, double> Quotes { get; set; }
    }
}