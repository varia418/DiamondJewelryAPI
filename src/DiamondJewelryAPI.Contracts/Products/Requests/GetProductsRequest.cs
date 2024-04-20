namespace DiamondJewelryAPI.Contracts.Products.Requests;

public record GetProductsRequest(
    string? Brand,
    string? Material,
    string? ChainMaterial,
    string? Purity,
    string? Gender,
    string? Color,
    string? Group,
    string? Type,
    string SortMode = "latest", // oldest, mostPopular
    int Limit = 0
);
