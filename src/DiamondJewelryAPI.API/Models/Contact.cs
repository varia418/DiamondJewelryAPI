using DiamondJewelryAPI.API.Models.Common;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class Contact : BaseModel
{
    [BsonElement("sender_name")]
    public string Name { get; init; }

    [BsonElement("sender_email")]
    public string Email { get; init; }

    [BsonElement("content")]
    public string Content { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Contact() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}