using Conversion.Domain.Models;
using Newtonsoft.Json;

namespace Conversion.Application.ViewModel
{
    public class CurrencyViewModel
    {
        [JsonProperty(PropertyName = "currency")]
        public Currency Currency { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; set; } = new ValidationResult();
    }
}