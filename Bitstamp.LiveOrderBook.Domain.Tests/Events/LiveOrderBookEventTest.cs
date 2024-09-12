using Bitstamp.LiveOrderBook.Domain.Constants;
using Bitstamp.LiveOrderBook.Domain.Events;
using Bitstamp.LiveOrderBook.Domain.Tests.Doubles.Fake;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Events;

public class LiveOrderBookEventTest
{
    [Fact(DisplayName = "Validate streaming bitstamp event")]
    public void Should_EventsStreamingBitstampEvent_Validate()
    {
        // Arrange
        LiveOrderBookEvent liveOrderBookEvent = new LiveOrderBookEvent();
        
        // Act
        liveOrderBookEvent.Timestamp = new TimeSpan(DateTime.Now.Ticks).ToString();
        liveOrderBookEvent.Microtimestamp = new TimeSpan(DateTime.Now.Ticks).ToString();
        liveOrderBookEvent.Bids = BidsFake.CreateBids();
        liveOrderBookEvent.Asks = AsksFake.CreateAsks();

        // Assert
        liveOrderBookEvent.Should().NotBeNull();
        liveOrderBookEvent.Should().BeAssignableTo<LiveOrderBookEvent>();
        liveOrderBookEvent.Microtimestamp.Should().NotBeNull();
        liveOrderBookEvent.Microtimestamp.Should().NotBeEmpty();
        liveOrderBookEvent.Microtimestamp.Should().BeAssignableTo<string>();
        liveOrderBookEvent.Timestamp.Should().NotBeNull();
        liveOrderBookEvent.Timestamp.Should().NotBeEmpty();
        liveOrderBookEvent.Timestamp.Should().BeAssignableTo<string>();
        liveOrderBookEvent.Asks.Should().NotBeNull();
        liveOrderBookEvent.Asks.Should().NotBeEmpty();
        liveOrderBookEvent.Asks.Should().NotContainNulls();
        liveOrderBookEvent.Asks.Should().BeAssignableTo<List<string[]>>();
        liveOrderBookEvent.Asks.Should().AllBeAssignableTo<string[]>();
        liveOrderBookEvent.Asks.Should().HaveCount(100);
        liveOrderBookEvent.Bids.Should().NotBeNull();
        liveOrderBookEvent.Bids.Should().NotBeEmpty();
        liveOrderBookEvent.Bids.Should().NotContainNulls();
        liveOrderBookEvent.Bids.Should().BeAssignableTo<List<string[]>>();
        liveOrderBookEvent.Bids.Should().AllBeAssignableTo<string[]>();
        liveOrderBookEvent.Bids.Should().HaveCount(100);
    }
}