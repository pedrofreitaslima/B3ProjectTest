using System.Text;
using System.Text.Json;
using Bitstamp.LiveOrderBook.Domain.Events;
using Bitstamp.LiveOrderBook.WorkerService.Repositories.Abstractions;
using RabbitMQ.Client;

namespace Bitstamp.LiveOrderBook.WorkerService.Repositories.Concretes;

public class RabbitMqRepository : IRabbitMqRepository
{
    private readonly ILogger<RabbitMqRepository> _logger;

    public RabbitMqRepository(ILogger<RabbitMqRepository> logger)
    {
        _logger = logger;
    }
    
    public async Task SendEvent(StreamingBitstampEvent streamingBitstampEvent)
    {
        _logger.LogInformation("Sending message to rabbitmq");
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: streamingBitstampEvent.ChannelName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var message = JsonSerializer.Serialize(streamingBitstampEvent.LiveOrderBookEvent);
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            "",
            streamingBitstampEvent.ChannelName,
            false,
            body
        );
    }
}