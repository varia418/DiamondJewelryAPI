using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Products.Responses;

public record SearchProductByTitleResponse(
    Product[] Products
);