using Bitstamp.LiveOrderBook.Domain.Constants;
using Bitstamp.LiveOrderBook.Domain.Events;
using Bitstamp.LiveOrderBook.Domain.Tests.Doubles.Fake;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Events;

public class StreamingBitstampEventTest
{
    [Fact(DisplayName = "Validate streaming bitstamp event")]
    public void Should_EventsStreamingBitstampEvent_Validate()
    {
        // Arrange
        StreamingBitstampEvent streamingBitstampEvent = new StreamingBitstampEvent();
        LiveOrderBookEvent liveOrderBookEvent = new LiveOrderBookEvent();
        liveOrderBookEvent.Timestamp = new TimeSpan(DateTime.Now.Ticks).ToString();
        liveOrderBookEvent.Microtimestamp = new TimeSpan(DateTime.Now.Ticks).ToString();
        liveOrderBookEvent.Bids = BidsFake.CreateBids();
        liveOrderBookEvent.Asks = AsksFake.CreateAsks();
        
        // Act
        streamingBitstampEvent.ChannelName = SharedConstant.WebSocketConfiguration.CurrencyPairBtcUsd;
        streamingBitstampEvent.EventName = SharedConstant.WebSocketConfiguration.ChannelName;
        streamingBitstampEvent.LiveOrderBookEvent = liveOrderBookEvent;

        // Assert
        bool valid = streamingBitstampEvent.ChannelName.Equals(SharedConstant.WebSocketConfiguration.CurrencyPairBtcUsd);
        valid.Should().BeTrue();

        valid = streamingBitstampEvent.EventName.Equals(SharedConstant.WebSocketConfiguration.ChannelName);
        valid.Should().BeTrue();

        streamingBitstampEvent.LiveOrderBookEvent.Should().NotBeNull();
        streamingBitstampEvent.LiveOrderBookEvent.Should().BeAssignableTo<LiveOrderBookEvent>();
        streamingBitstampEvent.LiveOrderBookEvent.Microtimestamp.Should().NotBeNull();
        streamingBitstampEvent.LiveOrderBookEvent.Microtimestamp.Should().NotBeEmpty();
        streamingBitstampEvent.LiveOrderBookEvent.Microtimestamp.Should().BeAssignableTo<string>();
        streamingBitstampEvent.LiveOrderBookEvent.Timestamp.Should().NotBeNull();
        streamingBitstampEvent.LiveOrderBookEvent.Timestamp.Should().NotBeEmpty();
        streamingBitstampEvent.LiveOrderBookEvent.Timestamp.Should().BeAssignableTo<string>();
        streamingBitstampEvent.LiveOrderBookEvent.Asks.Should().NotBeNull();
        streamingBitstampEvent.LiveOrderBookEvent.Asks.Should().NotBeEmpty();
        streamingBitstampEvent.LiveOrderBookEvent.Asks.Should().NotContainNulls();
        streamingBitstampEvent.LiveOrderBookEvent.Asks.Should().BeAssignableTo<List<string[]>>();
        streamingBitstampEvent.LiveOrderBookEvent.Asks.Should().AllBeAssignableTo<string[]>();
        streamingBitstampEvent.LiveOrderBookEvent.Asks.Should().HaveCount(100);
        streamingBitstampEvent.LiveOrderBookEvent.Bids.Should().NotBeNull();
        streamingBitstampEvent.LiveOrderBookEvent.Bids.Should().NotBeEmpty();
        streamingBitstampEvent.LiveOrderBookEvent.Bids.Should().NotContainNulls();
        streamingBitstampEvent.LiveOrderBookEvent.Bids.Should().BeAssignableTo<List<string[]>>();
        streamingBitstampEvent.LiveOrderBookEvent.Bids.Should().AllBeAssignableTo<string[]>();
        streamingBitstampEvent.LiveOrderBookEvent.Bids.Should().HaveCount(100);
    }
}