
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

public class BaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; init; }
}