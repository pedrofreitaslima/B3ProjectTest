using System.Text.Json.Serialization;
using Bitstamp.LiveOrderBook.Domain.Constants;

namespace Bitstamp.LiveOrderBook.Domain.Dtos;

public class LiveOrderBookBtc
{
    public LiveOrderBookBtc()
    {
        CurrencyPair = SharedConstant.WebSocketConfiguration.CurrencyPairBtcUsd;
        CorrelationId = Guid.NewGuid();
    }
    /// <summary>
    /// Unique number (hash) to identity dto event
    /// </summary>
    [JsonPropertyName("correlation_id")]
    public Guid CorrelationId { get; init; }
    /// <summary>
    /// Currency pair name
    /// </summary>
    [JsonPropertyName("currency_pair")]
    public string CurrencyPair { get; init; }
    
    /// <summary>
    /// List of top 100 bids
    /// </summary>
    [JsonPropertyName("bids")]
    public IEnumerable<string[]> Bids { get; set; }
    /// <summary>
    /// List of top 100 asks
    /// </summary>
    [JsonPropertyName("asks")]
    public IEnumerable<string[]> Asks { get; set; }
    /// <summary>
    /// Order book timestamp
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }
    /// <summary>
    /// Order book microtimestamp
    /// </summary>
    [JsonPropertyName("microtimestamp")]
    public string Microtimestamp { get; set; } 
}