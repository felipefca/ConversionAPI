using Conversion.Domain.Models;
using Newtonsoft.Json;

namespace Conversion.Application.ViewModel
{
    public class SingleCoinViewModel
    {
        [JsonProperty(PropertyName = "coins")]
        public Coins Coins { get; set; }
    }
}