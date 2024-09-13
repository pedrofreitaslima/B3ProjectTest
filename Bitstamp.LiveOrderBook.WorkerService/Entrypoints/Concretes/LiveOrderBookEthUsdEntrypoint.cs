using System.Text;
using Bitstamp.LiveOrderBook.Domain.Constants;
using Bitstamp.LiveOrderBook.Domain.Entities.WebSocket;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Repositories.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Services.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Services.Concretes;

namespace Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Concretes;

public class LiveOrderBookEthUsdEntrypoint : IEntrypointBase
{
    private readonly ILogger<LiveOrderBookEthUsdEntrypoint> _logger;
    private readonly string _channelName;
    private readonly string _currencyPairName;
    private SubscribeChannelEntity? _subscribeChannelEntity;
    private UnsubscribeChannelEntity? _unsubscribeChannelEntity;
    private readonly IConsumeStreamingService _consumeStreamingService;

    public LiveOrderBookEthUsdEntrypoint(ILogger<LiveOrderBookEthUsdEntrypoint> logger,
        IRabbitMqRepository rabbitMqRepository)
    {
        _logger = logger;
        _consumeStreamingService = new ConsumeStreamingService(logger,rabbitMqRepository);
        _channelName = SharedConstant.WebSocketConfiguration.ChannelName;
        _currencyPairName = SharedConstant.WebSocketConfiguration.CurrencyPairEthUsd;
    }
    public async Task Run(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Work service running live order book eth/usd entrypoint");
        CreateRequestsToWebSocket();
        if (_subscribeChannelEntity != null &&
            _unsubscribeChannelEntity != null)
        {
            await _consumeStreamingService.ConnectServer(stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                await _consumeStreamingService.SubscribeInChannel(
                    Encoding.ASCII.GetBytes(_subscribeChannelEntity.ToString()),
                    stoppingToken
                );
                await _consumeStreamingService.ConsumeStreaming(stoppingToken);
                await _consumeStreamingService.UnsubscribeInChannel(
                    Encoding.ASCII.GetBytes(_unsubscribeChannelEntity.ToString()),
                    stoppingToken
                );
                await Task.Delay(5000, stoppingToken);
            }

            await _consumeStreamingService.CloseServer(stoppingToken);
        }
    }

    public void CreateRequestsToWebSocket()
    {
        var dataChannelEntity = new DataChannelEntity(CreateChannelToSend());
        _subscribeChannelEntity = new SubscribeChannelEntity(dataChannelEntity);
        _unsubscribeChannelEntity = new UnsubscribeChannelEntity(dataChannelEntity);
    }

    private string CreateChannelToSend() => $"{_channelName}_{_currencyPairName}";
}