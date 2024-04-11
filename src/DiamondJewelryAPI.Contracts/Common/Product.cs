namespace DiamondJewelryAPI.Contracts.Common;

public record Product(
    string Id,
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
    string Group,
    string Type
);