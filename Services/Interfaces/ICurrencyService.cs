using System.Threading.Tasks;
using Services.Responses;

namespace Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<ResponseCurrency> GetComparativeCurrency(string currencySource, string currencyTo);
    }
}