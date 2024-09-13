namespace Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Abstractions;

public interface IEntrypointBase
{
    Task Run(CancellationToken stoppingToken);
    void CreateRequestsToWebSocket();
}