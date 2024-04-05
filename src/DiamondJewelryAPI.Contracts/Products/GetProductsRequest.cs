namespace DiamondJewelryAPI.Contracts.Products;

public record GetProductsRequest(
    string? Brand,
    string? Material,
    string? ChainMaterial,
    string? Purity,
    string? Gender,
    string? Color,
    string? Group,
    string? Type,
    string SortMode = "latest",
    int Limit = 0
);
