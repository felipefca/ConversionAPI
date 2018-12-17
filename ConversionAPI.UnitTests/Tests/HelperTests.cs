using System.Collections.Generic;
using Conversion.CrossCutting.Helpers;
using Conversion.Domain.Models;
using ConversionAPI.UnitTests.Fakes;
using Xunit;

namespace ConversionAPI.UnitTests.Tests
{
    public class HelperTests
    {
        [Theory]
        [InlineData(0, 2, 0)]
        [InlineData(1, 2, 2)]
        [InlineData(10, 20, 200)]
        [InlineData(100, 2.97, 297)]
        [InlineData(75.37, 3.98, 299.9726)]
        public void Should_MultiplyAmount_Success_Return_Equal(double amount, double value, double expected)
        {
            //Arrange
            var helper = new Helper();

            //Act
            var result = helper.MultiplyAmount(amount, value);

            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(3, 3, 8)]
        [InlineData(100, 2.97, 296)]
        public void Should_MultiplyAmount_Success_Return_NotEqual(double amount, double value, double expected)
        {
            //Arrange
            var helper = new Helper();

            //Act
            var result = helper.MultiplyAmount(amount, value);

            //Assert
            Assert.NotEqual(result, expected);
        }

        [Fact]
        public void Should_CalculateAmount_Success_Return_Equal_MultiplyAmount_Currency_Greater_Than_One()
        {
            //Arrange
            double amount = 100;
            double currencySource = 1;
            double currencyTo = 2.5;
            double expected = 250;
            var helper = new Helper();

            //Act
            var result = helper.CalculateAmount(amount, currencySource, currencyTo);

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Should_CalculateAmount_Success_Return_Equal_MultiplyAmount_Currency_Less_Than_One()
        {
            //Arrange
            double amount = 100;
            double currencySource = 1;
            double currencyTo = 0.59;
            double expected = 59;
            var helper = new Helper();

            //Act
            var result = helper.CalculateAmount(amount, currencySource, currencyTo);

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Should_CalculateAmount_Success_Return_Equal_Amount()
        {
            //Arrange
            double amount = 100;
            double currencySource = 1;
            double currencyTo = 1;
            double expected = 100;
            var helper = new Helper();

            //Act
            var result = helper.CalculateAmount(amount, currencySource, currencyTo);

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Should_FormatAmount_Success_Return_Value()
        {
            //Arrange
            double value = 100;
            string expected = value.ToString("N2");
            var helper = new Helper();

            //Act
            var result = helper.FormatAmount(value);

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Should_AdjustCurrency_Success_Return_Equal_Value()
        {
            //Arrange
            var helper = new Helper();
            var currency = new Currency();
            var coin = "USDBRL";
            currency.CoinTo = coin;
            var coinSourceExpected = "USD";
            var coinToExpected = "BRL";

            //Act
            var result = helper.AdjustCurrency(currency);

            //Assert
            Assert.Equal(result.CoinSource, coinSourceExpected);
            Assert.Equal(result.CoinTo, coinToExpected);
        }

        [Fact]
        public void Should_AdjustCurrency_Success_Return_NotEqual_Value()
        {
            //Arrange
            var helper = new Helper();
            var currency = new Currency();
            var coin = "USDBRL";
            currency.CoinTo = coin;
            var coinSourceExpected = "BRL";
            var coinToExpected = "USD";

            //Act
            var result = helper.AdjustCurrency(currency);

            //Assert
            Assert.NotEqual(result.CoinSource, coinSourceExpected);
            Assert.NotEqual(result.CoinTo, coinToExpected);
        }

        [Fact]
        public void Should_ConvertDictionaryToCurrency_Success_Return()
        {
            //Arrange
            var helper = new Helper();
            var dictionary = new Dictionary<string, double>
            {
                { "key1", 2.5 }
            };
            var coinToExpected = "key1";
            var valueExpected = 2.5;

            //Act
            var result = helper.ConvertDictionaryToCurrency(dictionary);

            //Assert
            Assert.Equal(result.CoinTo, coinToExpected);
            Assert.Equal(result.Value, valueExpected);
        }

        [Fact]
        public void Should_ConvertDictionaryTo_Success_Return_Equal()
        {
            //Arrange
            var helper = new Helper();
            var dictionary = new Dictionary<string, string>
            {
                { "BRL", "Brazilian Real" }
            };

            var coinExpected = ReturnFakes.GetCoinsFake();

            //Act
            var result = helper.ConvertDictionaryTo(dictionary);

            //Assert
            foreach (var item in result)
            {
                Assert.Equal(item.Initial, coinExpected.Initial);
                Assert.Equal(item.Description, coinExpected.Description);
            }
        }
    }
}