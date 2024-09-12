using System.Text.Json.Serialization;

namespace Bitstamp.LiveOrderBook.Domain.Events;

public class StreamingBitstampEvent
{
    /// <summary>
    /// Data received in the event streaming
    /// </summary>
    [JsonPropertyName("data")]
    public LiveOrderBookEvent LiveOrderBookEvent { get; set; }
    /// <summary>
    /// Channel name of the streaming received
    /// </summary>
    [JsonPropertyName("channel")]
    public string ChannelName { get; set; }
    /// <summary>
    /// Event name of the streaming received
    /// </summary>
    [JsonPropertyName("event")]
    public string EventName { get; set; }
}