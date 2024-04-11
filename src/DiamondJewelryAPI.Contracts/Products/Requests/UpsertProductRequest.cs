using DiamondJewelryAPI.Contracts.Products.Common;

namespace DiamondJewelryAPI.Contracts.Products.Requests;

public record UpsertProductRequest(
    Product Product
);