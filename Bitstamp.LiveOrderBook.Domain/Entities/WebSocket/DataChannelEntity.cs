namespace Bitstamp.LiveOrderBook.Domain.Entities.WebSocket;

public class DataChannelEntity
{
    public DataChannelEntity(string channelName)
    {
        ChannelName = channelName;
    }
    public string ChannelName { get; init; }
}