using Conversion.Domain.Models;
using Newtonsoft.Json;

namespace Conversion.Application.ViewModel
{
    public class ResultConversionViewModel
    {
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public double Currency { get; set; }

        [JsonProperty(PropertyName = "total")]
        public double Total { get; set; }

        [JsonProperty(PropertyName = "totalConverted")]
        public string TotalConverted { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; set; } = new ValidationResult();
    }
}