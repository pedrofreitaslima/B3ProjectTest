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
    
    public async Task SendEvent(LiveOrderBookEvent liveOrderBookEvent)
    {
        _logger.LogInformation("Sending message to rabbitmq");
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        var queueName = "live_order_book_btcusd";

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var message = JsonSerializer.Serialize(liveOrderBookEvent);
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            "",
            queueName,
            false,
            body
        );
    }
}