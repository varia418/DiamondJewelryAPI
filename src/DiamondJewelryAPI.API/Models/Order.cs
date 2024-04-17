using DiamondJewelryAPI.API.Common.Attributes;
using DiamondJewelryAPI.API.Models.Common;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class Order : BaseModel
{
    [BsonElement("user_id")]
    public string UserId { get; init; }

    [BsonElement("items")]
    public IList<CartItem> Items { get; init; }

    [BsonElement("address")]
    public string Address { get; init; }

    [BsonElement("status")]
    public string Status { get; init; }

    [BsonElement("VAT_fee")]
    public string VATFee { get; init; }

    [BsonElement("total_cost")]
    public string TotalCost { get; init; }

    [BsonElement("created_at")]
    [BsonSerializer(typeof(BsonStringDateTimeSerializer))]
    public string CreatedAt { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Order() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}