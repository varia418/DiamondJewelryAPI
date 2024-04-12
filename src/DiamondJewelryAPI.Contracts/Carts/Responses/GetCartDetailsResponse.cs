using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Carts.Responses;

public record GetCartDetailsResponse(
    CartData Cart
);