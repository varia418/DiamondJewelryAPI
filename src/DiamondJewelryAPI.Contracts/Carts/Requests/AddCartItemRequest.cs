namespace DiamondJewelryAPI.Contracts.Carts.Requests;

public record AddCartItemRequest(
    string Id,
    int Quantity
);