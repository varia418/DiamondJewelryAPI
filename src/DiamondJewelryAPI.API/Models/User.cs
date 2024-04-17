using DiamondJewelryAPI.API.Models.Common;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class User : BaseModel
{
    [BsonElement("full_name")]
    public string FullName { get; init; }

    [BsonElement("dob")]
    public string DateOfBirth { get; init; }

    [BsonElement("tel")]
    public string PhoneNumber { get; init; }

    [BsonElement("email")]
    public string Email { get; init; }

    [BsonElement("address")]
    public string Address { get; init; }

    [BsonElement("password")]
    public string Password { get; set; }

    [BsonElement("favorite_products")]
    [BsonRepresentation(BsonType.ObjectId)]
    public IList<string> FavoriteProducts { get; init; }

    [BsonElement("role")]
    public string Role { get; init; }

    [BsonElement("provider")]
    public string Provider { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}