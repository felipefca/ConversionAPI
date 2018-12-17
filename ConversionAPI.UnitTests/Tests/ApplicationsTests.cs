using System.Threading.Tasks;
using Conversion.Application.Applications;
using Conversion.Application.ViewModel;
using Conversion.CrossCutting.Helpers;
using Conversion.Domain.Models;
using ConversionAPI.UnitTests.Fakes;
using Moq;
using NSubstitute;
using Services.Interfaces;
using Xunit;

namespace ConversionAPI.UnitTests.Tests
{
    public class ApplicationsTests
    {
        [Fact]
        public async Task Should_GetAllCoins_Success_Return_False()
        {
            //Arrange
            var coinServiceMock = new Mock<ICoinService>();
            var helpersMock = new Mock<IHelper>();

            coinServiceMock.Setup(x => x.GetAllCoins()).Returns(Task.FromResult(ReturnFakes.GetResponseCoinsFalseFake()));

            helpersMock.Setup(s => s.ConvertDictionaryTo(ReturnFakes.GetDictionaryCoinsFake()))
                .Returns(ReturnFakes.GetListCoinsFake);

            var coinApplication = new CoinApplication(coinServiceMock.Object, helpersMock.Object);

            //Act
            var content = await coinApplication.GetAllCoins();

            //Assert
            Assert.False(content.Validation.IsSuccess);
        }

        [Fact]
        public async Task Should_GetAllCoins_Success_Return_True()
        {
            //Arrange
            var coinServiceMock = new Mock<ICoinService>();
            var helpersMock = new Mock<IHelper>();

            coinServiceMock.Setup(x => x.GetAllCoins()).Returns(Task.FromResult(ReturnFakes.GetResponseCoinsTrueFake()));

            helpersMock.Setup(s => s.ConvertDictionaryTo(ReturnFakes.GetDictionaryCoinsFake()))
                .Returns(ReturnFakes.GetListCoinsFake);

            var coinApplication = new CoinApplication(coinServiceMock.Object, helpersMock.Object);

            //Act
            var content = await coinApplication.GetAllCoins();

            //Assert
            Assert.True(content.Validation.IsSuccess);
        }

        [Fact]
        public async Task Should_GetAllCoins_Success_Return_NotNull()
        {
            //Arrange
            var coinServiceMock = new Mock<ICoinService>();
            var helpersMock = new Mock<IHelper>();

            coinServiceMock.Setup(x => x.GetAllCoins()).Returns(Task.FromResult(ReturnFakes.GetResponseCoinsTrueFake()));

            helpersMock.Setup(s => s.ConvertDictionaryTo(ReturnFakes.GetDictionaryCoinsFake()))
                .Returns(ReturnFakes.GetListCoinsFake);

            var coinApplication = new CoinApplication(coinServiceMock.Object, helpersMock.Object);

            //Act
            var content = await coinApplication.GetAllCoins();

            //Assert
            Assert.NotNull(content);
        }

        [Fact]
        public async Task Should_GetComparativeCurrency_Success_Return_False()
        {
            //Arrange
            var currencyServiceMock = new Mock<ICurrencyService>();
            var helpersMock = new Mock<IHelper>();
            var coinSource = "BRL";
            var coinTo = "USD";
            var currency = new Currency();
            var coin = "USDBRL";
            currency.CoinTo = coin;

            currencyServiceMock.Setup(x => x.GetComparativeCurrency(coinSource, coinTo)).Returns(Task.FromResult(ReturnFakes.GetResponseCurrencyFalseFake()));

            helpersMock.Setup(s => s.ConvertDictionaryToCurrency(ReturnFakes.GetDictionaryCurrencyFake()))
                .Returns(ReturnFakes.GetCurrencyFake);

            helpersMock.Setup(s => s.AdjustCurrency(currency)).Returns(ReturnFakes.GetCurrencyFake);

            var coinApplication = new CurrencyApplication(currencyServiceMock.Object, helpersMock.Object);

            //Act
            var content = await coinApplication.GetComparativeCurrency(coinSource, coinTo);

            //Assert
            Assert.False(content.Validation.IsSuccess);
        }

        [Fact]
        public async Task Should_GetComparativeCurrency_Success_Return_True()
        {
            //Arrange
            var currencyServiceMock = new Mock<ICurrencyService>();
            var helpersMock = new Mock<IHelper>();
            var coinSource = "BRL";
            var coinTo = "USD";
            var currency = new Currency();
            var coin = "USDBRL";
            currency.CoinTo = coin;

            currencyServiceMock.Setup(x => x.GetComparativeCurrency(coinSource, coinTo)).Returns(Task.FromResult(ReturnFakes.GetResponseCurrencyTrueFake()));

            helpersMock.Setup(s => s.ConvertDictionaryToCurrency(ReturnFakes.GetDictionaryCurrencyFake()))
                .Returns(ReturnFakes.GetCurrencyFake);

            helpersMock.Setup(s => s.AdjustCurrency(currency)).Returns(ReturnFakes.GetCurrencyFake);

            var coinApplication = new CurrencyApplication(currencyServiceMock.Object, helpersMock.Object);

            //Act
            var content = await coinApplication.GetComparativeCurrency(coinSource, coinTo);

            //Assert
            Assert.True(content.Validation.IsSuccess);
        }

        [Fact]
        public async Task Should_GetComparativeCurrency_Success_Return_NotNull()
        {
            //Arrange
            var currencyServiceMock = new Mock<ICurrencyService>();
            var helpersMock = new Mock<IHelper>();
            var coinSource = "BRL";
            var coinTo = "USD";
            var currency = new Currency();
            var coin = "USDBRL";
            currency.CoinTo = coin;

            currencyServiceMock.Setup(x => x.GetComparativeCurrency(coinSource, coinTo)).Returns(Task.FromResult(ReturnFakes.GetResponseCurrencyTrueFake()));

            helpersMock.Setup(s => s.ConvertDictionaryToCurrency(ReturnFakes.GetDictionaryCurrencyFake()))
                .Returns(ReturnFakes.GetCurrencyFake);

            helpersMock.Setup(s => s.AdjustCurrency(currency)).Returns(ReturnFakes.GetCurrencyCompleteFake);

            var coinApplication = new CurrencyApplication(currencyServiceMock.Object, helpersMock.Object);

            //Act
            var content = await coinApplication.GetComparativeCurrency(coinSource, coinTo);

            //Assert
            Assert.NotNull(content);
        }

        [Fact]
        public void Should_ConvertToCurrency_Success_Return_NotNull()
        {
            //Arrange
            var helpersMock = new Mock<IHelper>();
            var body = new ConversionViewModel
            {
                Amount = 100,
                CoinSource = "BRL",
                CoinTo = "USD",
                CurrencySource = 1,
                CurrencyTo = 3.91
            };

            helpersMock.Setup(x => x.CalculateAmount(body.Amount, body.CurrencySource, body.CurrencyTo)).Returns(391);
            helpersMock.Setup(x => x.FormatAmount(391)).Returns("391,00");

            var conversionApplication = new ConversionApplication(helpersMock.Object);

            //Act
            var content = conversionApplication.ConvertToCurrency(body);

            //Assert
            Assert.NotNull(content);
        }

        [Theory]
        [InlineData(100, 2.7, 270)]
        [InlineData(50, 0.86, 43)]
        public void Should_ConvertToCurrency_Success_Return_Equal_TotalValue(double amount, double currencyTo, double expected)
        {
            //Arrange
            var helpersMock = new Mock<IHelper>();
            var body = new ConversionViewModel
            {
                Amount = amount,
                CoinSource = "BRL",
                CoinTo = "USD",
                CurrencySource = 1,
                CurrencyTo = currencyTo
            };

            var total = amount * currencyTo;

            helpersMock.Setup(x => x.CalculateAmount(body.Amount, body.CurrencySource, body.CurrencyTo)).Returns(total);
            helpersMock.Setup(x => x.FormatAmount(total)).Returns(Arg.Any<string>());

            var conversionApplication = new ConversionApplication(helpersMock.Object);

            //Act
            var content = conversionApplication.ConvertToCurrency(body);

            //Assert
            Assert.Equal(content.Total, expected);
        }

        [Theory]
        [InlineData(100, 2.7, "270,00")]
        [InlineData(50, 0.86, "43,00")]
        public void Should_ConvertToCurrency_Success_Return_Equal_TotalConvertedValue(double amount, double currencyTo, string expected)
        {
            //Arrange
            var helpersMock = new Mock<IHelper>();
            var body = new ConversionViewModel
            {
                Amount = amount,
                CoinSource = "BRL",
                CoinTo = "USD",
                CurrencySource = 1,
                CurrencyTo = currencyTo
            };

            var total = amount * currencyTo;
            var totalConverted = total.ToString("N2");

            helpersMock.Setup(x => x.CalculateAmount(body.Amount, body.CurrencySource, body.CurrencyTo)).Returns(total);
            helpersMock.Setup(x => x.FormatAmount(total)).Returns(totalConverted);

            var conversionApplication = new ConversionApplication(helpersMock.Object);

            //Act
            var content = conversionApplication.ConvertToCurrency(body);

            //Assert
            Assert.Equal(content.TotalConverted, expected);
        }

        [Fact]
        public void Should_GetBrazilianCoin_Success_Return_Equal()
        {
            //Arrange
            var expected = ReturnFakes.GetBrazilianCoineFake();
            var coinServiceMock = new Mock<ICoinService>();
            var helpersMock = new Mock<IHelper>();

            coinServiceMock.Setup(x => x.GetAllCoins()).Returns(Task.FromResult(ReturnFakes.GetResponseCoinsTrueFake()));

            helpersMock.Setup(s => s.ConvertDictionaryTo(ReturnFakes.GetDictionaryCoinsFake()))
                .Returns(ReturnFakes.GetListCoinsFake);

            var coinApplication = new CoinApplication(coinServiceMock.Object, helpersMock.Object);

            //Act
            var content = coinApplication.GetBrazilianCoin();

            //Assert
            Assert.Equal(content.Coins.Initial, expected.Coins.Initial);
            Assert.Equal(content.Coins.Description, expected.Coins.Description);
        }
    }
}