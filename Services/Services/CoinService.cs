using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Services.Interfaces;
using Services.Responses;

namespace Services.Services
{
    public class CoinService : ServiceBase, ICoinService
    {
        public async Task<ResponseCoins> GetAllCoins()
        {
            var url = UrlBase + GetCoinsResource;

            var client = new RestClient(url);
            var request = new RestRequest("", Method.GET);
            request.AddParameter(KeyDescription, KeyValue); 

            var response = await client.ExecuteTaskAsync(request, CancellationToken.None);
            var content = JsonConvert.DeserializeObject<ResponseCoins>(response.Content);

            return content;
        }
    }
}