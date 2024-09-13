using System.Globalization;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Concretes;
using Bitstamp.LiveOrderBook.WorkerService.Services.Abstractions;

namespace Bitstamp.LiveOrderBook.WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly LiveOrderBookBtcUsdEntrypoint _liveOrderBookBtcUsdEntrypoint;
    private readonly LiveOrderBookEthUsdEntrypoint _liveOrderBookEthUsdEntrypoint;

    public Worker(ILogger<Worker> logger, 
        LiveOrderBookBtcUsdEntrypoint liveOrderBookBtcUsdEntrypoint,
        LiveOrderBookEthUsdEntrypoint liveOrderBookEthUsdEntrypoint)
    {
        _logger = logger;
        _liveOrderBookBtcUsdEntrypoint = liveOrderBookBtcUsdEntrypoint;
        _liveOrderBookEthUsdEntrypoint = liveOrderBookEthUsdEntrypoint;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        
        var taskBtcUsd = Task.Factory.StartNew(() => _liveOrderBookBtcUsdEntrypoint.Run(stoppingToken));
        var taskEthUsd = Task.Factory.StartNew(() => _liveOrderBookEthUsdEntrypoint.Run(stoppingToken));
        Task.WaitAll(taskBtcUsd, taskEthUsd);
    }
    

}