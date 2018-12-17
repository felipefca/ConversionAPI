using System.Threading.Tasks;
using Conversion.Application.ViewModel;

namespace Conversion.Application.Interfaces
{
    public interface ICurrencyApplication
    {
        Task<CurrencyViewModel> GetComparativeCurrency(string coinSource, string coinTo);
    }
}