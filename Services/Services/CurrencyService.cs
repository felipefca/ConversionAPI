using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Services.Interfaces;
using Services.Responses;

namespace Services.Services
{
    public class CurrencyService : ServiceBase, ICurrencyService
    {
        public async Task<ResponseCurrency> GetComparativeCurrency(string coinSource, string coinTo)
        {
            var url = UrlBase + GetComparativeCurrencyResource;

            var client = new RestClient(url);
            var request = new RestRequest("", Method.GET);

            request.AddParameter(KeyDescription, KeyValue);
            request.AddParameter("currencies", coinTo);
            request.AddParameter("source", coinSource);

            var response = await client.ExecuteTaskAsync(request, CancellationToken.None);
            var content = JsonConvert.DeserializeObject<ResponseCurrency>(response.Content);

            return content;
        }
    }
}