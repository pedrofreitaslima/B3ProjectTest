using System.Runtime.InteropServices;
using Bitstamp.LiveOrderBook.Domain.Entities.WebSocket;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Entities.WebSocket;

public class DataChannelEntityTest
{
    [Theory(DisplayName = "Validate web socket data channel entity")]
    [InlineData("btcusd")]
    [InlineData("ehtusd")]
    [InlineData("eurusd")]
    [InlineData("etheur")]
    [InlineData("btceur")]
    public void Should_EntityWebSocket_DataChannelEntity_Validate(string channelName)
    {
        // Arrange
        DataChannelEntity entity = new DataChannelEntity(channelName);

        // Act
        bool valid = entity.ChannelName.Equals(channelName);

        // Assert
        valid.Should().BeTrue();
    }
}