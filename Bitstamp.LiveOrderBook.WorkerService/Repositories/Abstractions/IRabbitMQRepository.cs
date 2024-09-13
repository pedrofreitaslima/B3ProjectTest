using Bitstamp.LiveOrderBook.Domain.Events;

namespace Bitstamp.LiveOrderBook.WorkerService.Repositories.Abstractions;

public interface IRabbitMqRepository
{
    Task SendEvent(LiveOrderBookEvent liveOrderBookEvent);
}