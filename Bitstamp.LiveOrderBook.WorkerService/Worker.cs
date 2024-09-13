using System.Net.WebSockets;
using Bitstamp.LiveOrderBook.Domain.Constants;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Abstractions;

namespace Bitstamp.LiveOrderBook.WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ClientWebSocket _clientWebSocket;
    private readonly IEntrypointBase _entrypointBase;

    public Worker(ILogger<Worker> logger, 
        ClientWebSocket clientWebSocket,
        IEntrypointBase entrypointBase)
    {
        _logger = logger;
        _clientWebSocket = clientWebSocket;
        _entrypointBase = entrypointBase;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _entrypointBase.Run(stoppingToken);
            await Task.Delay(5000, stoppingToken);
        }
    }
    

}