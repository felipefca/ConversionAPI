using System.Collections.Generic;
using Conversion.Domain.Models;
using Newtonsoft.Json;

namespace Conversion.Application.ViewModel
{
    public class CoinsViewModel
    {
        [JsonProperty(PropertyName = "coins")]
        public IList<Coins> Coins { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; set; } = new ValidationResult();
    }
}