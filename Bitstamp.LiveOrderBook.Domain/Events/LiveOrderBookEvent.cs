using System.Text.Json.Serialization;

namespace Bitstamp.LiveOrderBook.Domain.Events;

/// <summary>
/// Event to live order book
/// </summary>
public class LiveOrderBookEvent
{
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