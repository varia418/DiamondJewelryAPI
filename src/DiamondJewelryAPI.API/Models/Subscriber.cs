using DiamondJewelryAPI.API.Models.Common;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class Subscriber : BaseModel
{
    [BsonElement("email")]
    public string Email { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Subscriber() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}