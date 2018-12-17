using System.Net;
using System.Threading.Tasks;
using Conversion.Domain.Models;
using ConversionAPI.IntegrationTests.Configuration;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace ConversionAPI.IntegrationTests.Tests
{
    public class CurrencyControllerTests
    {
        [Fact]
        public async Task Currency_GetComparativeCurrency_ReturnsOkResponse()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/currency/GetComparativeCurrency?coinSource=BRL&coinTo=USD";

                //Act
                var response = await client.GetAsync(baseUrl);

                //Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Currency_GetAllCoins_Returns_Success_Content()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/currency/GetComparativeCurrency?coinSource=BRL&coinTo=USD";

                //Act
                var response = await client.GetAsync(baseUrl);

                //Assert
                var content = JsonConvert.DeserializeObject<Currency>(await response.Content.ReadAsStringAsync());
                Assert.NotNull(content);
            }
        }
    }
}