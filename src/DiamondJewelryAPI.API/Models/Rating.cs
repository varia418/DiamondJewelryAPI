using DiamondJewelryAPI.API.Common.Attributes;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class Rating : BaseModel
{
    [BsonElement("user_id")]
    public string UserId { get; init; }

    [BsonElement("product_id")]
    public string ProductId { get; init; }

    [BsonElement("rating_star")]
    public float RatingScore { get; init; }

    [BsonElement("content")]
    public string Content { get; init; }

    [BsonElement("createdAt")]
    [BsonSerializer(typeof(BsonStringDateTimeSerializer))]
    public string CreatedAt { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Rating() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}