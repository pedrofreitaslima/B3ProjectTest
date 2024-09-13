namespace Bitstamp.LiveOrderBook.WorkerService.Services.Abstractions;

public interface IConsumeStreamingService
{
    Task SubscribeInChannel(byte[] data, CancellationToken stoppingToken);
    Task UnsubscribeInChannel(byte[] data, CancellationToken stoppingToken);
    Task ConsumeStreaming(CancellationToken stoppingToken);
    Task ConnectServer(CancellationToken stoppingToken);
    Task CloseServer(CancellationToken stoppingToken);
}