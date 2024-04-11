namespace DiamondJewelryAPI.Contracts.Carts.Requests;

public record RemoveCartItemRequest(
    string UserId,
    string ProductId
);