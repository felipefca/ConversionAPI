namespace Conversion.Domain.Models
{
    public class Currency
    {
        public string CoinSource { get; set; }
        public string CoinTo { get; set; }
        public double SourceValue { get; set; }
        public double Value { get; set; }
    }
}