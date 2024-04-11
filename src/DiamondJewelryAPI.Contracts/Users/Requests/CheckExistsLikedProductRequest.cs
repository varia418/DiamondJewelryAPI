namespace DiamondJewelryAPI.Contracts.Users.Requests;

public record CheckExistsLikedProductRequest(
    string Id,
    string ProductId
);