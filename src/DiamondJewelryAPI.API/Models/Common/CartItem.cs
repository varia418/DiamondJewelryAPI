using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models.Common;

public record CartItem
{
    [BsonElement("product_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string ProductId { get; init; }

    [BsonElement("quantity")]
    public int Quantity { get; set; }
}

public record CartItemDetails(Product? Product, int Quantity);