using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Conversion.Application.ViewModel;
using ConversionAPI.IntegrationTests.Configuration;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace ConversionAPI.IntegrationTests.Tests
{
    public class ConversionControllerTests
    {
        [Fact]
        public async Task Conversion_ConvertToCurrency_ReturnsOkResponse()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/Conversion/ConvertToCurrency";

                var body = new ConversionViewModel
                {
                    Amount = 100,
                    CoinSource = "BRL",
                    CoinTo = "USD",
                    CurrencySource = 1,
                    CurrencyTo = 3.91
                };

                var parameters = new StringContent(JsonConvert.SerializeObject(body));
                parameters.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //Act
                var response = await client.PostAsync(baseUrl, parameters);

                //Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Coins_ConvertToCurrency_Returns_Success_Content()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/conversion/ConvertToCurrency";

                var body = new ConversionViewModel
                {
                    Amount = 100,
                    CoinSource = "BRL",
                    CoinTo = "USD",
                    CurrencySource = 1,
                    CurrencyTo = 3.91
                };

                var parameters = new StringContent(JsonConvert.SerializeObject(body));
                parameters.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //Act
                var response = await client.PostAsync(baseUrl, parameters);

                //Assert
                var content = JsonConvert.DeserializeObject<ResultConversionViewModel>(await response.Content.ReadAsStringAsync());
                Assert.NotNull(content);
            }
        }

        [Fact]
        public async Task Coins_ConvertToCurrency_Returns_Success_Equal_Content()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/conversion/ConvertToCurrency";

                var body = new ConversionViewModel
                {
                    Amount = 100,
                    CoinSource = "BRL",
                    CoinTo = "USD",
                    CurrencySource = 1,
                    CurrencyTo = 3.91
                };

                var totalExpected = body.Amount * body.CurrencyTo;
                var totalConvertedExpected = totalExpected.ToString("N2");

                var parameters = new StringContent(JsonConvert.SerializeObject(body));
                parameters.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //Act
                var response = await client.PostAsync(baseUrl, parameters);

                //Assert
                var content = JsonConvert.DeserializeObject<ResultConversionViewModel>(await response.Content.ReadAsStringAsync());
                Assert.Equal(totalExpected, content.Total);
                Assert.Equal(totalConvertedExpected, content.TotalConverted);
            }
        }

        [Fact]
        public async Task Coins_ConvertToCurrency_Returns_BadRequest_Value_Null()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/conversion/ConvertToCurrency";

                var body = new ConversionViewModel();

                var parameters = new StringContent(JsonConvert.SerializeObject(body));
                parameters.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //Act
                var response = await client.PostAsync(baseUrl, parameters);

                //Assert
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }
    }
}