using System.Net.WebSockets;
using Bitstamp.LiveOrderBook.WorkerService;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Concretes;
using Bitstamp.LiveOrderBook.WorkerService.Repositories.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Repositories.Concretes;
using Bitstamp.LiveOrderBook.WorkerService.Services.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Services.Concretes;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IEntrypointBase, LiveOrderBookBtcUsdEntrypoint>();
        services.AddSingleton<IConsumeStreamingService, ConsumeStreamingService>();
        services.AddSingleton<IRabbitMqRepository,RabbitMqRepository>();
        services.AddTransient<ClientWebSocket>();
    })
    .Build();

await host.RunAsync();