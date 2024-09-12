using Bitstamp.LiveOrderBook.Domain.Constants;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Constants;

public class ShareConstantTest
{
    [Fact(DisplayName = "Validate connection string name")]
    public void Should_ConnectionString_Validate()
    {
        // Arrange
        string connectionStringName = "wss://ws.bitstamp.net";
        
        // Act
        var connectionStringValid = SharedConstant.WebSocketConfiguration.ConnectionString.Equals(connectionStringName);

        // Assert
        connectionStringValid.Should().BeTrue();
    }

    [Fact(DisplayName = "Validate channel name")]
    public void Should_ChannelName_Validate()
    {
        // Arrange
        string channelName = "live_order_book";
        
        // Act
        var channelNameValid = SharedConstant.WebSocketConfiguration.ChannelName.Equals(channelName);

        // Assert
        channelNameValid.Should().BeTrue();
    }
    
    [Theory(DisplayName = "Validate currencies pairs name")]
    [InlineData("btcusd")]
    [InlineData("ethusd")]
    public void Should_CurrencyPairs_Validate(string currencyPairName)
    {
        // Arrange   
        var currenciesPairs = GetCurrencisPairsConstants();

        // Act
        var currencyPairValid = currenciesPairs.Contains(currencyPairName);

        // Assert
        currencyPairValid.Should().BeTrue();
    }

    private IEnumerable<string> GetCurrencisPairsConstants()
    {
        List<string> currenciesPairs = new List<string>();
        currenciesPairs.Add(SharedConstant.WebSocketConfiguration.CurrencyPairBtc);
        currenciesPairs.Add(SharedConstant.WebSocketConfiguration.CurrencyPairEth);
        return currenciesPairs;
    }
}