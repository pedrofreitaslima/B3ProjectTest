using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Bitstamp.LiveOrderBook.Domain.Constants;
using Bitstamp.LiveOrderBook.Domain.Events;
using Bitstamp.LiveOrderBook.WorkerService.Repositories.Abstractions;
using Bitstamp.LiveOrderBook.WorkerService.Services.Abstractions;

namespace Bitstamp.LiveOrderBook.WorkerService.Services.Concretes;

public class ConsumeStreamingService : IConsumeStreamingService
{
    private readonly ILogger<ConsumeStreamingService> _logger;
    private readonly ClientWebSocket _clientWebSocket;
    private readonly IRabbitMqRepository _rabbitMqRepository;
    
    public ConsumeStreamingService(ILogger<ConsumeStreamingService> logger,
        ClientWebSocket clientWebSocket,
        IRabbitMqRepository rabbitMqRepository)
    {
        _logger = logger;
        _clientWebSocket = clientWebSocket;
        _rabbitMqRepository = rabbitMqRepository;
    }

    public async Task SubscribeInChannel(byte[] data, CancellationToken stoppingToken)
    {
        await _clientWebSocket.SendAsync(data, WebSocketMessageType.Text, true,stoppingToken);
        _logger.LogInformation("Worker service subscribed in web socket Bitstamp");
    }

    public async Task UnsubscribeInChannel(byte[] data, CancellationToken stoppingToken)
    {
        await _clientWebSocket.SendAsync(data, WebSocketMessageType.Text, true, stoppingToken);
        _logger.LogInformation("Worker service unsubscribed in web socket Bitstamp");
    }

    public async Task ConsumeStreaming(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker is consuming the live order book streaming");
        bool consumeStreaming = true;
        string dataEvent = string.Empty;
        var buffer = new byte[1024];
        do
        {
            var result = await _clientWebSocket.ReceiveAsync(buffer, stoppingToken);

            if (result is { EndOfMessage: true, Count: 0 })
                consumeStreaming = false;
            else
            {
                string dataStream = Encoding.ASCII.GetString(buffer, 0, result.Count);
                if (!dataStream.Contains("bts:subscription_succeeded")) 
                    dataEvent += dataStream;
            }
        }
        while (consumeStreaming);
        
        StreamingBitstampEvent eventStreaming = JsonSerializer.Deserialize<StreamingBitstampEvent>(dataEvent) ??
                                               throw new ArgumentNullException("Streaming data is null");

        await _rabbitMqRepository.SendEvent(eventStreaming.LiveOrderBookEvent);
        
        _logger.LogInformation("Worker consumed the live order book streaming");
    }
    
    public async Task ConnectServer(CancellationToken stoppingToken)
    {
        await _clientWebSocket.ConnectAsync(new Uri(SharedConstant.WebSocketConfiguration.ConnectionString), stoppingToken);
        _logger.LogInformation("Worker connected at server: {channelName}", SharedConstant.WebSocketConfiguration.ConnectionString);
    }
    
    public async Task CloseServer(CancellationToken stoppingToken)
    {
        await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
            "Worker Service consume streaming done", stoppingToken);
        _logger.LogInformation("Worker closed connection at server: {channelName}", SharedConstant.WebSocketConfiguration.ConnectionString);
    }
}