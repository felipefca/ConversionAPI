using System.Threading.Tasks;
using Services.Responses;

namespace Services.Interfaces
{
    public interface ICoinService
    {
        Task<ResponseCoins> GetAllCoins();
    }
}