using System.Text;
using Bitstamp.LiveOrderBook.Domain.Constants;
using Bitstamp.LiveOrderBook.Domain.Entities.WebSocket;
using Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Services.Abstractions;

namespace Bitstamp.LiveOrderBook.WorkerService.Entrypoints.Concretes;

public class LiveOrderBookBtcUsdEntrypoint : IEntrypointBase
{
    private readonly ILogger<LiveOrderBookBtcUsdEntrypoint> _logger;
    private readonly string _channelName;
    private readonly string _currencyPairName;
    private SubscribeChannelEntity? _subscribeChannelEntity;
    private UnsubscribeChannelEntity? _unsubscribeChannelEntity;
    private readonly IConsumeStreamingService _consumeStreamingService;

    public LiveOrderBookBtcUsdEntrypoint(ILogger<LiveOrderBookBtcUsdEntrypoint> logger,
        IConsumeStreamingService consumeStreamingService)
    {
        _logger = logger;
        _consumeStreamingService = consumeStreamingService;
        _channelName = SharedConstant.WebSocketConfiguration.ChannelName;
        _currencyPairName = SharedConstant.WebSocketConfiguration.CurrencyPairBtcUsd;
    }
    public async Task Run(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Work service running live order book btc/usd entrypoint");
        CreateRequestsToWebSocket();
        if (_subscribeChannelEntity != null &&
            _unsubscribeChannelEntity != null)
        {
            await _consumeStreamingService.ConnectServer(stoppingToken);
            await _consumeStreamingService.SubscribeInChannel(
                Encoding.ASCII.GetBytes(_subscribeChannelEntity.ToString()),
                stoppingToken
            );
            await _consumeStreamingService.ConsumeStreaming(stoppingToken);
            await _consumeStreamingService.UnsubscribeInChannel(
                Encoding.ASCII.GetBytes(_unsubscribeChannelEntity.ToString()),
                stoppingToken
            );
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