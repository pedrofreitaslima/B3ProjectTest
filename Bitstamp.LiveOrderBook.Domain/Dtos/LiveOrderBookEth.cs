using System.Text.Json.Serialization;
using Bitstamp.LiveOrderBook.Domain.Constants;

namespace Bitstamp.LiveOrderBook.Domain.Dtos;

public class LiveOrderBookEth
{
    public LiveOrderBookEth()
    {
        _currencyPair = SharedConstant.WebSocketConfiguration.CurrencyPairBtc;
        _correlationId = Guid.NewGuid();
    }
    
    private readonly Guid _correlationId;
    private readonly string _currencyPair;
    
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