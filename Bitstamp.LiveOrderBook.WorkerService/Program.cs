using Bitstamp.LiveOrderBook.WorkerService;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Concretes;
using Bitstamp.LiveOrderBook.WorkerService.Repositories.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Repositories.Concretes;
using Bitstamp.LiveOrderBook.WorkerService.Services.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Services.Concretes;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<LiveOrderBookBtcUsdEntrypoint>();
        services.AddSingleton<LiveOrderBookEthUsdEntrypoint>();
        services.AddSingleton<IRabbitMqRepository,RabbitMqRepository>();
    })
    .Build();

await host.RunAsync();