using DiamondJewelryAPI.API.Common.Attributes;
using DiamondJewelryAPI.API.Models.Common;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class Order : BaseModel
{
    [BsonElement("user_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; init; }

    [BsonElement("items")]
    public IList<CartItem> Items { get; init; }

    [BsonElement("address")]
    public string Address { get; set; }

    [BsonElement("status")]
    public string Status { get; private set; }

    [BsonElement("VAT_fee")]
    public double VATFee { get; init; }

    [BsonElement("total_cost")]
    public double TotalCost { get; init; }

    [BsonElement("created_at")]
    [BsonSerializer(typeof(BsonStringDateTimeSerializer))]
    public DateTime CreatedAt { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Order() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public void UpdateStatus(string status)
    {
        Status = status;
    }
}