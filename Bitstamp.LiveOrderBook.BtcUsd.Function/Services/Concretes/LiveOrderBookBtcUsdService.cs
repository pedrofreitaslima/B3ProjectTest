using System.Text;
using Bitstamp.LiveOrderBook.BtcUsd.Function.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Bitstamp.LiveOrderBook.BtcUsd.Function.Services.Concretes;

public class LiveOrderBookBtcUsdService : ILiveOrderBookBtcUsdService
{
    private readonly IMongoCollection<Domain.Entities.MongoDB.LiveOrderBook> _collection;
    private readonly IChannel _channel;
    private readonly AsyncEventingBasicConsumer _consumer;
    private string QueueName;
    
    public LiveOrderBookBtcUsdService(IConfiguration configuration)
    {
        _channel = ConfigureRabbitMq(configuration).GetAwaiter().GetResult();
        _consumer = new AsyncEventingBasicConsumer(_channel); 
        _collection = ConfigureMongoDb(configuration);
    }

    private async Task<IChannel> ConfigureRabbitMq(IConfiguration configuration)
    {
        string connectionString = configuration.GetRequiredSection("RabbitMqSettings:HostName").Value ?? "localhost";
        QueueName = configuration.GetRequiredSection("RabbitMqSettings:QueueName").Value ?? "teste";
        var factory = new ConnectionFactory { HostName = connectionString };
        
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        
        await channel.QueueDeclareAsync(queue: QueueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        
        
        return channel;
    }

    private IMongoCollection<Domain.Entities.MongoDB.LiveOrderBook> ConfigureMongoDb(IConfiguration configuration)
    {
        var connectionString = configuration.GetRequiredSection("MongoDbSettings:ConnectionString").Value;
        var databaseName = configuration.GetRequiredSection("MongoDbSettings:DatabaseName").Value;
        var collectionName = configuration.GetRequiredSection("MongoDbSettings:CollectionName").Value;
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseName);
        return mongoDatabase.GetCollection<Domain.Entities.MongoDB.LiveOrderBook>
            (collectionName);
    }


    public async Task Add(Domain.Entities.MongoDB.LiveOrderBook liveOrderBook)
    {
        await _collection.InsertOneAsync(liveOrderBook);
    }

    public async Task Consume()
    {
        bool keepGoingConsume = true;
        do
        {
            Console.WriteLine(" [*] Waiting for messages.");
            _consumer.Received += async (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");

                int dots = message.Split('.').Length - 1;
                Thread.Sleep(dots * 1000);

                Console.WriteLine(" [x] Done");

                // here channel could also be accessed as ((EventingBasicConsumer)sender).Model
                await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            
            await _channel.BasicConsumeAsync(queue: QueueName ,
                autoAck: false,
                consumer: _consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        } while (keepGoingConsume);
    }
    
}