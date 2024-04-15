
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization;

using DiamondJewelryAPI.API.Common.Attributes;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiamondJewelryAPI.API.Models;

[BsonIgnoreExtraElements]
public class Product : BaseModel
{
    [BsonElement("title")]
    public string Title { get; init; }
    [BsonElement("price")]
    public float Price { get; init; }
    [BsonElement("description")]
    public string Description { get; init; }
    [BsonElement("details")]
    public ProductDetails Details { get; init; }
    [BsonElement("group")]
    public string Group { get; init; }
    [BsonElement("image")]
    public string Image { get; init; }
    [BsonElement("stock")]
    public int Stock { get; init; }
    [BsonElement("sold")]
    public int Sold { get; init; }
    [BsonElement("created_at")]
    [BsonSerializer(typeof(BsonStringDateTimeSerializer))]
    public DateTime CreatedAt { get; init; }

    public Product() { }

    private Product(
        string title,
        float price,
        string description,
        ProductDetails details,
        string group,
        string image,
        int stock,
        int sold,
        DateTime createdAt
    )
    {
        Title = title;
        Price = price;
        Description = description;
        Details = details;
        Group = group;
        Image = image;
        Stock = stock;
        Sold = sold;
        CreatedAt = createdAt;
    }

    public static Product Create(
        string title,
        float price,
        string description,
        ProductDetails details,
        string group,
        string image,
        int stock,
        int sold = 0
    )
    {
        return new Product(title, price, description, details, group, image, stock, sold, DateTime.Now);
    }
}

public record ProductDetails()
{
    [BsonElement("brand")]
    public string Brand { get; init; } = String.Empty;
    [BsonElement("material")]
    public string Material { get; init; } = String.Empty;
    [BsonElement("chain_material")]
    public string ChainMaterial { get; init; } = String.Empty;
    [BsonElement("purity")]
    public string Purity { get; init; } = String.Empty;
    [BsonElement("gender")]
    public string Gender { get; init; } = String.Empty;
    [BsonElement("color")]
    public string Color { get; init; } = String.Empty;
    [BsonElement("type")]
    public string Type { get; init; } = String.Empty;
}