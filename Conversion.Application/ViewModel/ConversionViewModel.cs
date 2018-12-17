using Newtonsoft.Json;

namespace Conversion.Application.ViewModel
{
    public class ConversionViewModel
    {
        [JsonProperty(PropertyName = "coinSource")]
        public string CoinSource { get; set; }

        [JsonProperty(PropertyName = "coinTo")]
        public string CoinTo { get; set; }

        [JsonProperty(PropertyName = "currencySource")]
        public double CurrencySource { get; set; }

        [JsonProperty(PropertyName = "currencyTo")]
        public double CurrencyTo { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }
    }
}