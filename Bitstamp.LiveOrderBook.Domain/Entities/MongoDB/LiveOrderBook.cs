using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bitstamp.LiveOrderBook.Domain.Entities.MongoDB;

public class LiveOrderBook
{
    [BsonId]
    [BsonRequired]
    [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonRequired]
    [BsonElement("microtimestamp"), BsonRepresentation(BsonType.String)]
    public string? Microtimestamp { get; set; }
    
    [BsonElement("timestamp"), BsonRepresentation(BsonType.String)]
    public string? Timestamp { get; set; }
    
    [BsonRequired]
    [BsonElement("currency_pair_name"), BsonRepresentation(BsonType.String)]
    public string? CurrencyPairName { get; set; }
    
    [BsonElement("bids")]
    public IEnumerable<string[]> Bids { get; set; }
    
    [BsonElement("asks")]
    public IEnumerable<string[]> Asks { get; set; }
}