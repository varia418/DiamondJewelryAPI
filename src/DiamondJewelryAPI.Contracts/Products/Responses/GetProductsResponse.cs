using DiamondJewelryAPI.Contracts.Products.Common;

namespace DiamondJewelryAPI.Contracts.Products.Responses;

public record GetProductsResponse(
    Product[] Products
);
