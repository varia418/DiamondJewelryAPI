using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Carts.Requests;

public record UpsertCartRequest(
    CartData Cart
);