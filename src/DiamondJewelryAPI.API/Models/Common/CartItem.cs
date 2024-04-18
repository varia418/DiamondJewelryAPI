using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models.Common;

public record CartItem
{
    [BsonElement("product_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductId { get; init; }

    [BsonElement("quantity")]
    public int Quantity { get; init; }
}

public record CartItemDetails(Product? Product, int Quantity);