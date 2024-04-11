namespace DiamondJewelryAPI.Contracts.Carts.Requests;

public record AddCartItemRequest(
    string UserId,
    string ProductId,
    int Quantity
);