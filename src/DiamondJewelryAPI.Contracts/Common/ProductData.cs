namespace DiamondJewelryAPI.Contracts.Common;

public record ProductData(
    string? Id,
    string Title,
    string Description,
    ProductDetails Details,
    string Group,
    string Image,
    string CreatedAt,
    int Price = 0,
    int Stock = 0,
    int Sold = 0
);

public record ProductDetails(
    string Brand,
    string Material,
    string ChainMaterial,
    string Purity,
    string Gender,
    string Color,
    string Type
);


// public record Product
// {
//     public string? Id;
//     public string Title;
//     public string Description;
//     public ProductDetails? Details;
//     public string Group;
//     public string Image;
//     public string CreatedAt;
//     public int Price = 0;
//     public int Stock = 0;
//     public int Sold = 0;

//     // public Product() { }

//     public Product(
//         string? id,
//         string title,
//         int price,
//         string description,
//         ProductDetails details,
//         string group,
//         string image,
//         int stock,
//         int sold,
//         DateTime createdAt)
//     {
//         Id = id;
//         Title = title;
//         Price = price;
//         Description = description;
//         Details = details;
//         Group = group;
//         Image = image;
//         Stock = stock;
//         Sold = sold;
//         CreatedAt = createdAt.ToString();
//     }
// };