namespace Bitstamp.LiveOrderBook.Domain.Entities.WebSocket;

public class UnsubscribeChannelEntity
{
    public UnsubscribeChannelEntity(DataChannelEntity data)
    {
        _eventName = "bts:unsubscribe";
        Data = data;
    }

    private readonly string _eventName;
    public DataChannelEntity Data { get; private set; }

    public override string ToString()
    {
        return @"{""event"": """ 
               + _eventName +
               @""",""data"": {""channel"": """
               + Data.ChannelName +
               @"""}}";
    }
}