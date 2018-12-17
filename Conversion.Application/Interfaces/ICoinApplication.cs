using System.Threading.Tasks;
using Conversion.Application.ViewModel;

namespace Conversion.Application.Interfaces
{
    public interface ICoinApplication
    {
        Task<CoinsViewModel> GetAllCoins();
        SingleCoinViewModel GetBrazilianCoin();
    }
}