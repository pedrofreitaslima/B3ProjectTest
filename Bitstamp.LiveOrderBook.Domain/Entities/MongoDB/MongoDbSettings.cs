namespace Bitstamp.LiveOrderBook.Domain.Entities.MongoDB;

public class MongoDbSettings
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; } 
    public string? CollectionName { get; set; }
}