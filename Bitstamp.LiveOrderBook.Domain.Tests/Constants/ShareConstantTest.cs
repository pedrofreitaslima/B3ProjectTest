using Bitstamp.LiveOrderBook.Domain.Constants;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Constants;

public class ShareConstantTest
{
    [Fact(DisplayName = "Validate web socket configuration connection string name")]
    public void Should_WebSocketConfiguration_ConnectionString_Validate()
    {
        // Arrange
        string connectionStringName = "wss://ws.bitstamp.net";
        
        // Act
        var connectionStringValid = SharedConstant.WebSocketConfiguration.ConnectionString.Equals(connectionStringName);

        // Assert
        connectionStringValid.Should().BeTrue();
    }

    [Fact(DisplayName = "Validate web socket configuration channel name")]
    public void Should_WebSocketConfiguration_ChannelName_Validate()
    {
        // Arrange
        string channelName = "live_order_book";
        
        // Act
        var channelNameValid = SharedConstant.WebSocketConfiguration.ChannelName.Equals(channelName);

        // Assert
        channelNameValid.Should().BeTrue();
    }
    
    [Theory(DisplayName = "Validate web socket configuration currencies pairs name")]
    [InlineData("btcusd")]
    [InlineData("ethusd")]
    public void Should_WebSocketConfiguration_CurrencyPairs_Validate(string currencyPairName)
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