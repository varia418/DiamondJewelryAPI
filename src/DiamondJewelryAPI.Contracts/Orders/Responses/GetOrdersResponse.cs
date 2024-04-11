using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Orders.Responses;

public record GetOrdersResponse(
    Order[] Orders
);