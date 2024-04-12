using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Orders.Requests;

public record UpsertOrderRequest(OrderData Order);