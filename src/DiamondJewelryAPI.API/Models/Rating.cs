using DiamondJewelryAPI.API.Common.Attributes;
using DiamondJewelryAPI.API.Models.Common;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class Rating : BaseModel
{
    [BsonElement("user_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; init; }

    [BsonElement("product_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductId { get; init; }

    [BsonElement("rating_star")]
    public float RatingScore { get; init; }

    [BsonElement("content")]
    public string Content { get; init; }

    [BsonElement("createdAt")]
    [BsonSerializer(typeof(BsonStringDateTimeSerializer))]
    public DateTime CreatedAt { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Rating() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}