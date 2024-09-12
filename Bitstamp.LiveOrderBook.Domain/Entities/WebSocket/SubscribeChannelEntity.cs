namespace Bitstamp.LiveOrderBook.Domain.Entities.WebSocket;

public class SubscribeChannelEntity
{
    public SubscribeChannelEntity(DataChannelEntity data)
    {
        _eventName = "bts:subscribe";
        Data = data;
    }

    private readonly string _eventName;
    public DataChannelEntity Data { get; private set; }

    public override string ToString()
    {
        return @"{""event"": """ 
               + _eventName +
               @""",""data"": {""channel"": ""{"
               + Data.ChannelName +
               @"}""}}";
    }
}