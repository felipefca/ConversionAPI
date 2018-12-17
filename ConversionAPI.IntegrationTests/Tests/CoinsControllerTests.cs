using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Conversion.Domain.Models;
using ConversionAPI.IntegrationTests.Configuration;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace ConversionAPI.IntegrationTests.Tests
{
    public class CoinsControllerTests
    {
        [Fact]
        public async Task Coins_GetAllCoins_ReturnsOkResponse()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/coins/GetAllCoins";

                //Act
                var response = await client.GetAsync(baseUrl);

                //Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Coins_GetAllCoins_Returns_Success_Content()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/coins/GetAllCoins";

                //Act
                var response = await client.GetAsync(baseUrl);

                //Assert
                var content = JsonConvert.DeserializeObject<IList<Coins>>(await response.Content.ReadAsStringAsync()); 
                Assert.NotNull(content);
            }
        }

        [Fact]
        public async Task Coins_GetBrazilianCoin_ReturnsOkResponse()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/coins/GetBrazilianCoin";

                //Act
                var response = await client.GetAsync(baseUrl);

                //Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Coins_GetBrazilianCoin_Returns_Success_Content()
        {
            using (var client = new TestContext().Client)
            {
                //Arrange
                var baseUrl = "/api/coins/GetBrazilianCoin";

                //Act
                var response = await client.GetAsync(baseUrl);

                //Assert
                var content = JsonConvert.DeserializeObject<Coins>(await response.Content.ReadAsStringAsync());
                Assert.NotNull(content);
            }
        }
    }
}