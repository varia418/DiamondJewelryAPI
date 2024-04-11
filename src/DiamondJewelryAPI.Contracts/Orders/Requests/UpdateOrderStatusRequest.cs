namespace DiamondJewelryAPI.Contracts.Orders.Requests;

public record UpdateOrderStatusRequest(string Id, string Status);