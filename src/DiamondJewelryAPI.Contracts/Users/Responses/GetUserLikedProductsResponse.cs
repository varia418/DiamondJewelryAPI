using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Users.Requests;

public record GetUserLikedProductsResponse(
    Product[] Products
);