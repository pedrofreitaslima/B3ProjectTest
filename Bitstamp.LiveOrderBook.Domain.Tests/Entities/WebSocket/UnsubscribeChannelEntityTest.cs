using Bitstamp.LiveOrderBook.Domain.Entities.WebSocket;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Entities.WebSocket;

public class UnsubscribeChannelEntityTest
{
    [Theory(DisplayName = "Validate web socket subscribe channel entity")] 
    [InlineData("btcusd")]
    [InlineData("ehtusd")]
    [InlineData("eurusd")]
    [InlineData("etheur")]
    [InlineData("btceur")]
    public void Should_WebSocket_UnsubscribeChannelEntity_Validate(string channelName)
    {
        // Arrange
        DataChannelEntity data = new DataChannelEntity(channelName);
        UnsubscribeChannelEntity entity = new UnsubscribeChannelEntity(data);
        string expectedValue = ResultValue(channelName);
        
        // Act
        var result = entity.ToString();
        
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
        result.Should().BeAssignableTo<string>();
        bool valid = result.Equals(expectedValue);
        valid.Should().BeTrue();

    }

    private string ResultValue(string channelName) => @"{""event"": ""bts:unsubscribe"",""data"": {""channel"": ""{"
                                                      + channelName + @"}""}}";
}