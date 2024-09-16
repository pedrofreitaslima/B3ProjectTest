namespace Bitstamp.LiveOrderBook.BtcUsd.Function.Services.Abstractions;

public interface ILiveOrderBookBtcUsdService
{
    Task Add(Domain.Entities.MongoDB.LiveOrderBook liveOrderBook);
    Task Consume();
}