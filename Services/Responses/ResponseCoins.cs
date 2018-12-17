using System.Collections.Generic;
using Newtonsoft.Json;

namespace Services.Responses
{
    public class ResponseCoins : ResponseBase
    {
        [JsonProperty(PropertyName = "currencies")]
        public Dictionary<string, string> Currencies { get; set; }
    }
}