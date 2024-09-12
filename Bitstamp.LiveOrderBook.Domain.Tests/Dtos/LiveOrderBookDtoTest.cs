using Bitstamp.LiveOrderBook.Domain.Dtos;
using Bitstamp.LiveOrderBook.Domain.Tests.Doubles.Fake;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Dtos;

public class LiveOrderBookDtoTest
{
    [Fact(DisplayName = "Validate dto live order book btc")]
    public void Should_LiveOrderBookBtc_Validate()
    {
        // Arrange
        var dto = new LiveOrderBookBtc();
        var date = DateTime.Now;
        bool valid = false;
        
        // Act
        dto.Timestamp = new TimeSpan(date.Ticks).ToString();
        dto.Microtimestamp = new TimeSpan(date.Ticks).ToString();
        dto.Asks = AsksFake.CreateAsks();
        dto.Bids = BidsFake.CreateBids();

        // Assert
        string correlationid = dto.CorrelationId.ToString();
        correlationid.Should().NotBeNull();
        correlationid.Should().NotBeEmpty();
        correlationid.Should().BeAssignableTo<string>();

        dto.CurrencyPair.Should().NotBeNull();
        dto.CurrencyPair.Should().NotBeEmpty();
        dto.CurrencyPair.Should().Be("btcusd");
        
        valid = dto.Timestamp.Equals(new TimeSpan(date.Ticks).ToString());
        valid.Should().BeTrue();
        
        valid = dto.Microtimestamp.Equals(new TimeSpan(date.Ticks).ToString());
        valid.Should().BeTrue();

        var asks  = dto.Asks.ToList();
        asks.Should().NotBeNull();
        asks.Should().NotBeEmpty();
        asks.Should().HaveCount(100);
        asks.Should().AllBeAssignableTo<string[]>();
        
        var bids = dto.Asks.ToList();
        bids.Should().NotBeNull();
        bids.Should().NotBeEmpty();
        bids.Should().HaveCount(100);
        bids.Should().AllBeAssignableTo<string[]>();
    }
    
    [Fact(DisplayName = "Validate dto live order book btc")]
    public void Should_LiveOrderBookEth_Validate()
    {
        // Arrange
        var dto = new LiveOrderBookEth();
        var date = DateTime.Now;
        bool valid = false;
        
        // Act
        dto.Timestamp = new TimeSpan(date.Ticks).ToString();
        dto.Microtimestamp = new TimeSpan(date.Ticks).ToString();
        dto.Asks = AsksFake.CreateAsks();
        dto.Bids = BidsFake.CreateBids();

        // Assert
        string correlationid = dto.CorrelationId.ToString();
        correlationid.Should().NotBeNull();
        correlationid.Should().NotBeEmpty();
        correlationid.Should().BeAssignableTo<string>();

        dto.CurrencyPair.Should().NotBeNull();
        dto.CurrencyPair.Should().NotBeEmpty();
        dto.CurrencyPair.Should().Be("ethusd");
        
        valid = dto.Timestamp.Equals(new TimeSpan(date.Ticks).ToString());
        valid.Should().BeTrue();
        
        valid = dto.Microtimestamp.Equals(new TimeSpan(date.Ticks).ToString());
        valid.Should().BeTrue();

        var asks  = dto.Asks.ToList();
        asks.Should().NotBeNull();
        asks.Should().NotBeEmpty();
        asks.Should().NotContainNulls();
        asks.Should().HaveCount(100);
        asks.Should().BeAssignableTo<List<string[]>>();
        asks.Should().AllBeAssignableTo<string[]>();
        
        var bids = dto.Bids.ToList();
        bids.Should().NotBeNull();
        bids.Should().NotBeEmpty();
        bids.Should().NotContainNulls();
        bids.Should().HaveCount(100);
        bids.Should().BeAssignableTo<List<string[]>>();
        bids.Should().AllBeAssignableTo<string[]>();
    }
}